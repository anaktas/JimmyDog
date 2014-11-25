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
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\error.txt", "------JimmyDog Error File------");
            }
            // Πρόσθεσε το timestamp (την χρονοσφραγίδα της στιγμής της κλήσης αυτής της μεθόδου) και το μήνυμα σφάλματος σε μια γραμμή.
            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\error.txt", DateTime.Now.ToString() + ": " + errorText);
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
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\log.txt", "------JimmyDog Log File------");
            }
            // Πρόσθεσε το timestamp (την χρονοσφραγίδα της στιγμής της κλήσης αυτής της μεθόδου) και το μήνυμα καταγραφής σε μια γραμμή.
            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\log.txt", DateTime.Now.ToString() + ": " + logText);

        }
    }
}
