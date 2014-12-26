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
using System.Linq;
using System.Text;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Reflection;

namespace JimmyDog
{
    /// <summary>
    /// Κλάση καταγραφής γεγονότων και σφαλμάτων
    /// σε αρχεία καταγραφής.
    /// </summary>
    class Logger
    {
        /// <summary>
        /// Καταγραφή σφάλαματος σε αρχείο. Δέχεται ως όρισμα
        /// μια συμβολοσειρά και την αποθηκεύει σε ένα αρχείο
        /// που βρίσκεται στον φάκελο My Documents (error.txt).
        /// </summary>
        /// <param name="errorText">Μήνυμα σφάλματος</param>
        public static void error(String errorText) {
            // Αν το αρχείο δεν υπάρχει στον φάκελο My Documents...
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\error.txt")) 
            {
                // ...δημιούργησέ το.
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\error.txt", "------JimmyDog Error File------" + Environment.NewLine);
            }
            // Πρόσθεσε το timestamp (την χρονοσφραγίδα της στιγμής της κλήσης αυτής της μεθόδου) και το μήνυμα σφάλματος σε μια γραμμή.
            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\error.txt", DateTime.Now.ToString() + ": " + errorText + Environment.NewLine);
        }

        /// <summary>
        /// Καταγραφή μηνύματος εκτέλεσης σε αρχείο. Δέχεται
        /// ως όρισμα μια συμβολοσειρά και την αποθηκεύει σε
        /// ένα αρχείο στον φάκελο My Documents (log.txt).
        /// </summary>
        /// <param name="logText">Μήνυμα καταγραφής</param>
        public static void log(String logText) {
            // Αν το αρχείο δεν υπάρχειο στον φάκελο My Documents...
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\log.txt"))
            {
                // ...δημιούργησέ το.
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\log.txt", "------JimmyDog Log File------" + Environment.NewLine);
            }
            // Πρόσθεσε το timestamp (την χρονοσφραγίδα της στιγμής της κλήσης αυτής της μεθόδου) και το μήνυμα καταγραφής σε μια γραμμή.
            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\log.txt", DateTime.Now.ToString() + ": " + logText + Environment.NewLine);

        }
    }
}
