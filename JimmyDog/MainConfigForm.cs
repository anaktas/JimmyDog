//    Copyright (C) 2014  Daris Anastasios
//
//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; either version 2 of the License, or
//    (at your option) any later version.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License along
//    with this program; if not, write to the Free Software Foundation, Inc.,
//    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//    
//    Contact at: darisanastasios@gmail.com
//    License path /JimmyDog/JimmyDog/gpl-2.0.txt

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;

namespace JimmyDog
{
    public partial class MainConfigForm : Form
    {
        public MainConfigForm()
        {
            InitializeComponent();
        }

        // Χειρισμός μονού κλικ του menu item about
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Δημιουργία του αντικειμένου AboutBox
            AboutBox aboutForm = new AboutBox();
            // Εμφάνιση της φόρμας AboutBox
            aboutForm.Show();
        }

        // Χειρισμός μονού κλικ του menu item exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Αν ο server τρέχει, κλείστον.
            if (server.isRunning)
                server.stop();
            // Κλείσιμο της εφαρμογής
            // Κατοχυρώνουμε την τιμή true στην μεταβλητή exitFlag
            // Καταγράφουμε τον τερματισμό της εφαρμογής στο log.txt
            exitFlag = true;
            Logger.log("The application has ended.");
            this.Close();
        }

        // Χειρισμός μονού κλικ του menu item config 
        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Εμφάνιση της φόρμας ρυθμίσεων
            this.Show();
            // Ορισμός της κατάστασης του παραθύρου σε Normal
            this.WindowState = FormWindowState.Normal;
        }

        // Χειρισμός διπλού κλικ του εικονιδίου tray 
        private void notifyTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Εμφάνιση της φόρμας ρυθμίσεων
            this.Show();
            // Ορισμός της κατάστασης του παραθύρου σε Normal
            this.WindowState = FormWindowState.Normal;
        }

        // Χειρισμός γεγονότος φόρτωσης της φόρμας
        private void MainConfigForm_Load(object sender, EventArgs e)
        {
            // Αρχικοποιούμε την μεταβλητή exitFlag με την τιμή false
            exitFlag = false;
            // Απόκρυψη της φόρμας ρυθμίσεων
            this.Hide();
            // Εμφάνιση του "μπαλονιού" πληροφοριών
            notifyTrayIcon.ShowBalloonTip(500);
            // Απόκρυψη menu item start
            startToolStripMenuItem.Enabled = false;
            // Απόκρυψη του menu item stop
            stopToolStripMenuItem.Enabled = false;
            // Απόκρυψη του menu item restart
            restartToolStripMenuItem.Enabled = false;
            // Καταγραφή της εκκίνησης της εφαρμογής στο log.txt.
            Logger.log("The application has started.");
        }

        // Χειρισμός γεγονότος κλεισίματος της φόρμας
        private void MainConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Αν το exitFlag δεν είναι true
            // ακύρωσε το γεγονός του κλεισίματος και
            // απέκρυψε την φόρμα. Αλλιώς κλείσε.
            if (!exitFlag)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                // Θα μπορούσε να παραλειφθεί αυτό
                e.Cancel = false;
            }
        }

        // Χειρισμός μονού κλικ του menu item start
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Μετατρέπουμε την διεύθυνση IP που μας έδωσε ο χρήστης (η οποία είναι σε μορφή string)
            // σε τύπο IPAddres.
            IPAddress ipAddress = IPAddress.Parse(ipAddressString);
            // Καλούμε την μέθοδο start δίνοντας τις παραμέτρους που μας έδωσε ο χρήστης.
            // Αν επιστρέψει true, απενεργοποιούμε και ενεργοποιούμε τα κατάλληλα menu items.
            if (server.start(ipAddress, port, maxConnections, wwwPath))
            {
                // Απόκρυψη του menu item start
                startToolStripMenuItem.Enabled = false;
                // Εμφάνιση του menu item stop
                stopToolStripMenuItem.Enabled = true;
                // Εμφάνιση του menu item restart
                restartToolStripMenuItem.Enabled = true;
            }
            else 
            {
                // Αλλιώς αν η μέθοδος start του αντικειμένου HttpServer δώσει false, ενημέρωσε τον χρήστη.
                MessageBox.Show(this, "Κάτι πήγε στραβά! Μάλλον δεν δώσατε σωστές παραμέτρους. Προσπαθήστε ξανά.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Εμφάνισε το μπαλόνι πληροφοριών για την εκκίνηση του server.
            notifyTrayIcon.BalloonTipText = "Ο server ξεκίνησε.";
            notifyTrayIcon.ShowBalloonTip(200);
        }

        // Χειρισμός μονού κλικ του menu item stop
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Καλούμε την μέθοδο stop του αντικειμένου HttpServer για να σταματήσουμε τον server.
            // Ουσιαστικά κλείνουμε το socket του server (βλέπε τον κώδικα της μεθόδου).
            server.stop();
            // Απόκρυψη του menu item stop
            stopToolStripMenuItem.Enabled = false;
            // Εμφάνιση του menu item start
            startToolStripMenuItem.Enabled = true;
            // Εμφάνιση του menu item restart
            restartToolStripMenuItem.Enabled = false;
            // Εμφάνισε το μπαλόνι πληροφοριών για το σταμάτημα του server.
            notifyTrayIcon.BalloonTipText = "Ο server σταμάτησε.";
            notifyTrayIcon.ShowBalloonTip(200);
        }

        // Χειρισμός μονού κλικ του menu item restart
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(ipAddressString);
            // Κλείνουμε τον server...
            server.stop();
            // ...και τον ξανα-ανοίγουμε.
            if (server.start(ipAddress, port, 100, wwwPath))
            {
                // Απόκρυψη του menu item start
                startToolStripMenuItem.Enabled = false;
                // Εμφάνιση του menu item stop
                stopToolStripMenuItem.Enabled = true;
                // Εμφάνιση του menu item restart
                restartToolStripMenuItem.Enabled = true;
            }
            else 
            {
                // Ενημέρωσε τον χρήστη οτι κάτι πήγε στραβα.
                MessageBox.Show(this, "Κάτι πήγε στραβά! Μάλλον δεν δώσατε σωστές παραμέτρους. Προσπαθήστε ξανά.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Εμφάνισε το μπαλονι πληροφοριών για την επανεκκίνηση του server.
            notifyTrayIcon.BalloonTipText = "Ο server επανεκκίνησε.";
            notifyTrayIcon.ShowBalloonTip(200);
        }

        // Χειρισμός του μονού κλικ του κουμπιού "Αποθήκευση Ρυθμίσεων"
        // TO-DO: Θα πρέπει να γίνει validation των τιμών που εισάγει ο χρήστης.
        private void submittButton_Click(object sender, EventArgs e)
        {
            // Αν τρέχει ο server, κλείστον.
            if (server.isRunning)
                server.stop();
            // Απενεργοποίηση του κουμπιού.
            submittButton.Enabled = false;
            // Κατοχύρωση των τιμών των textboxes στις αντίστοιχες μεταβλητές
            ipAddressString = ipTextBox.Text.Trim();
            wwwPath = pathTextBox.Text.Trim();
            port = Convert.ToInt32(portTextBox.Text.Trim());
            maxConnections = Convert.ToInt32(maxConnectionBox.Text.Trim());
            // Ενημέρωσε τον χρήστη οτι όλα πήγαν καλά.
            MessageBox.Show(this, "Οι ρυθμίσεις αποθηκεύτηκαν.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Ενεργοποίηση του κουμπιού.
            submittButton.Enabled = true;
            // Ενεργοποίηση του menu item start
            startToolStripMenuItem.Enabled = true;
        }

        // Περιοχή μεταβλητών
        // H IP του server σε μορφή συμβολοσειράς. Θα την τροποποιήσουμε στην συνέχεια.
        private string ipAddressString;
        // Η διαδρομή του φακέλου των περιεχομένων. 
        private string wwwPath;
        // H θύρα
        private int port;
        // Ο μέγιστος αριθμός των συνδέσεων που μπορεί να δεχθεί ο server
        private int maxConnections;
        // Βοηθητικό flag για την αποτροπή του κλεισίματος της φόρμας και κατα
        // συνέπεια ολόκληρης της εφαρμογής, σε περίπτωση που ο χρήστης πατήσει το
        // εικονίδιο κλεισίματος.
        private bool exitFlag;
        // Το αντικείμενο του server
        HttpServer server = new HttpServer();
    }
}
