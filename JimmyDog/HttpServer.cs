using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JimmyDog
{
    /// <summary>
    /// Κλάση υλοποίησης http server
    /// </summary>
    class HttpServer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="maxConnections"></param>
        /// <param name="wwwPath"></param>
        /// <returns></returns>
        public bool start(IPAddress ipAddress, int port, int maxConnections, string wwwPath) 
        {
            if (isRunning)
                return false;

            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, port));
                serverSocket.Listen(maxConnections);
                serverSocket.ReceiveTimeout = transferTimeout;
                serverSocket.SendTimeout = transferTimeout;
                isRunning = true;
                this.wwwPath = wwwPath;
            }
            catch 
            {
                return false;
            }

            Thread requestListeningThread = new Thread(() =>
            {
                while (isRunning) 
                {
                    Socket clientSocket;
                    try
                    {
                        clientSocket = serverSocket.Accept();
                        Thread requestHandlingThread = new Thread(() => 
                        {
                            clientSocket.ReceiveTimeout = transferTimeout;
                            clientSocket.SendTimeout = transferTimeout;
                            try
                            {
                                httpRequestHandler(clientSocket);
                            }
                            catch
                            {
                                try
                                {
                                    clientSocket.Close();
                                }
                                catch
                                { 
                                    
                                }
                            }
                        });
                        requestHandlingThread.Start();
                    }
                    catch 
                    { 
                    
                    }
                }
            });
            requestListeningThread.Start();

            return true;
        }
        
        /// <summary>
        /// Μέθοδος χειρισμού ενός http request από ένα client
        /// </summary>
        /// <param name="clientSocket">To socket του client</param>
        private void httpRequestHandler(Socket clientSocket) 
        {
            // Ορίζουμε ένα buffer τύπου byte, χωριτηκότητας 10 kb
            // για να αποθηκεύσουμε το μήνυμα που θα παραλάβουμε από τον client
            byte[] buffer = new byte[10240];

            // Γεμίζουμε τον πίνακα buffer μέσω της μεθόδου Receive του αντικειμένου
            // Socket και καταμετρούμε τα bytes που παραλάβαμε σε μια μεταβλητή
            // receivedByteCount τύπου int.
            int receivedByteCount = clientSocket.Receive(buffer);
            
            // Μετατρέπουμε το μήνυμα που παραλάβαμε από έναν πίνακα byte σε μια
            // συμβολοσειρά (διαλέγοντας τις θέσεις του πίνακα στις οποίες καταχωρήθηκε το μήνυμα)
            string stringReceived = characterEncoder.GetString(buffer, 0, receivedByteCount);
            
            string httpMethod = stringReceived.Substring(0, stringReceived.IndexOf(" "));
            
            int start = stringReceived.IndexOf(httpMethod) + httpMethod.Length + 1;
            int length = stringReceived.LastIndexOf("HTTP") - start - 1;
            string requestedUrl = stringReceived.Substring(start, length);

            string requestedFile;
            if (httpMethod.Equals("GET"))
                requestedFile = requestedUrl.Split('?')[0];
            else 
            {
                return;
            }

            requestedFile = requestedFile.Replace("/", "\\").Replace("\\..", "");
            start = requestedFile.LastIndexOf(".") + 1;
            if (start > 0)
            {
                length = requestedFile.Length - start;
                string extension = requestedFile.Substring(start, length);
                if (contentExtensions.ContainsKey(extension))
                {
                    if (File.Exists(wwwPath + requestedFile))
                        responseOK(clientSocket, File.ReadAllBytes(wwwPath + requestedFile), contentExtensions[extension]);
                    else
                        notFound(clientSocket);
                }
            }
            else 
            {
                if (requestedFile.Substring(length - 1, 1) != "\\")
                    requestedFile += "\\";
                if (File.Exists(wwwPath + requestedFile + "index.htm"))
                    responseOK(clientSocket, File.ReadAllBytes(wwwPath + requestedFile + "\\index.htm"), "text/html");
                else if (File.Exists(wwwPath + requestedFile + "index.html"))
                    responseOK(clientSocket, File.ReadAllBytes(wwwPath + requestedFile + "\\index.html"), "text/html");
                else
                    notFound(clientSocket);
            }
        }

        /// <summary>
        /// Μέθοδος απόκρισης "404 Not Found" σε περίπτωση που 
        /// δεν υπάρχει το αρχείο στο directory
        /// </summary>
        /// <param name="clientSocket">To socket του client</param>
        private void notFound(Socket clientSocket) 
        {
            // Κλήση της υπερφορτωμένης μεθόδου response 
            response(clientSocket, "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"><title>404 - Not Found</title></head><body><h2>JimmyDog Server</h2><hr><div>404 - File not found</div></body></html>", "404 Not Found", "text/html");
        }

        /// <summary>
        /// Μέθοδος αποστολής του κωδικού "OK" στον client.
        /// </summary>
        /// <param name="clientSocket">To socket του client</param>
        /// <param name="byteContent">Το περιεχόμενο σε μορφή byte</param>
        /// <param name="contentType">Ο τύπος του περιεχομένου</param>
        private void responseOK(Socket clientSocket, byte[] byteContent, string contentType)
        {
            // Κλήση της βασικής μεθόδου response με τιμή για την μεταβλητή
            // responseCode "200 ΟΚ"
            response(clientSocket, byteContent, "200 OK", contentType);
        }

        /// <summary>
        /// Μέθοδος απόκρισης σε ένα request ενός client.
        /// Είναι η overloaded μέθοδος. Αντί το απεσταλμένο περιεχόμενο να είναι σε
        /// μορφή πίνακα byte, είναι σε συμβολοσειρά.
        /// </summary>
        /// <param name="clientSocket">To socket του client</param>
        /// <param name="stringContent">Το περιεχόμενο σε μορφή συμβολοσειράς</param>
        /// <param name="responseCode">Ο κωδικός απόκρισης</param>
        /// <param name="contentType">Ο τύπος του περιεχομένου</param>
        private void response(Socket clientSocket, string stringContent, string responseCode, string contentType) 
        {
            // Διαμόρφωση της μεταβλητής stringContent σε πίνακα byte 
            byte[] byteContent = characterEncoder.GetBytes(stringContent);
            // Κλήση της βασικής μεθόδου
            response(clientSocket, byteContent, responseCode, contentType);
        }
        
        /// <summary>
        /// Μέθοδος απόκρισης σε ένα request ενός client.
        /// Είναι η βασική μέθοδος.
        /// </summary>
        /// <param name="clientSocket">To socket του client</param>
        /// <param name="byteContent">To περιεχόμενο σε μορφή πίνακα byte</param>
        /// <param name="responseCode">Ο κωδικός απόκρισης</param>
        /// <param name="contentType">Ο τύπος του περιεχομένου</param>
        private void response(Socket clientSocket, byte[] byteContent, string responseCode, string contentType) 
        {
            try
            {
                // Δημιουργία του header του μηνύματος που αποστέλεται στον client
                byte[] byteHeader = characterEncoder.GetBytes(
                                    "HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: JimmyDog Server\r\n"
                                  + "Content-Length: " + byteContent.Length.ToString() + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
                // Αποστολή του header στον client
                clientSocket.Send(byteHeader);
                // Αποστολή του περιεχομένου στον client
                clientSocket.Send(byteContent);
                // Τερματισμός του clientSocket
                clientSocket.Close();
            }
            catch (SocketException exc)
            {
                // Αν προκύψει SocketException, κατέγραψέ το στο error.txt
                Logger.error(exc.Message);
                // και ενημέρωσε τον χρήστη για το σφάλμα
                MessageBox.Show(this, "Κάτι πήγε στραβά! O server δεν μπόρεσε να στείλει response στον client. Το μήνυμα σφάλματός είναι:\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                // Αν προκύψει Exception, κατέγραψέ το στο error.txt
                Logger.error(exc.Message);
                // και ενημέρωσε τον χρήστη για το σφάλμα
                MessageBox.Show(this, "Κάτι πήγε στραβά! O server δεν μπόρεσε να στείλει response στον client. Το μήνυμα σφάλματός είναι:\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Μέθοδος τερματισμού του server
        /// </summary>
        public void stop() 
        {
            // Τρέχει;
            if (isRunning) 
            {
                // Άλλαξε το flag
                isRunning = false;
                try
                {
                    // Προσπάθησε να τερμαστίσεις το socket του server
                    serverSocket.Close();
                }
                catch (SocketException exc)
                {
                    // Κατέγραψε το σφάλμα στον error.txt αν προκύψει SocketException
                    Logger.error(exc.Message);
                    // και ενημέρωσε τον χρήστη.
                    MessageBox.Show(this, "Κάτι πήγε στραβά! O server δεν μπόρεσε να κλείσει. Το μήνυμα σφάλματός είναι:\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exc)
                {
                    // Κατέγραψε το σφάλμα στον error.txt αν προκύψει γενικό Exception
                    Logger.error(exc.Message);
                    // και ενημέρωσε τον χρήστη.
                    MessageBox.Show(this, "Κάτι πήγε στραβά! O server δεν μπόρεσε να κλείσει. Το μήνυμα σφάλματός είναι:\n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Απελευθέρωσε τη μνήμη αποδευσμεύοντας το αντικείμενο serverSocket
                serverSocket = null;
            }
        }
        
        // Λεξικό των content types που υποστηρίζονται από τον server.
        // Μπορεί να επεκταθεί(:P). 
        private Dictionary<string, string> contentExtensions = new Dictionary<string, string>() 
        { 
            {"htm","text/html"},
            {"html","text/html"},
            {"xml","text/xml"},
            {"txt","text/plain"},
            {"js","text/javascript"},
            {"css","text/css"},
            {"png","image/png"},
            {"jpg","image/jpg"},
            {"gif","image/gif"}
        };
        
        // Flag για το αν τρέχει ο server
        public bool isRunning = false;
        // Χρονικό όριο του data transfer
        private int transferTimeout = 16;
        // Για την κωδικοποίηση χαρακτήρων
        private Encoding characterEncoder = Encoding.UTF8;
        // Το socket του server
        private Socket serverSocket;
        // Η διαδρομή του root φακέλου www
        private string wwwPath;
    }
}
