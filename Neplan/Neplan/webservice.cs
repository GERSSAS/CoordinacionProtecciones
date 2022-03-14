using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neplan_coordinacion.NeplanService;
using System.Xml;
using _Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Net;


namespace Neplan
{
    class Webservice
    {
        public NeplanServiceClient nepService;
        public ExternalProject ext;//Entrada debe ir entodos los desarrollos


        public string username = FormLogin.usuario; //nombre usurio 
        public string password = FormLogin.contraseña;//password usurio 
        public string yourURL = "https://neplan1.gers.co/Services/External/NeplanService.svc"; //direccion servidor de Cali
          //nombre del proyecto

        public Webservice()
        {
            ServicePointManager.ServerCertificateValidationCallback = ((sender2, certificate, chain, sslPolicyErrors) => true);//instantiates the neplaservice
            nepService = new NeplanServiceClient("WSHttpBinding_NeplanService", yourURL);//instantiates the neplaservice

            nepService.ClientCredentials.UserName.UserName = username; //obtine el username
            nepService.ClientCredentials.UserName.Password = getSHA1Hash(password); //obtine elpassword

            try
            {
                nepService.Open();//abre el servicio
                Console.WriteLine("Servicio abierto");
              //obtine el proyecto
           
            }
            catch
            {
                Console.WriteLine("Nosepudoabrirelservicio");
            }
        }


        public void CloseWebService()
        {
            try
            {
                nepService.Close();      //cerrando el servicio
                Console.WriteLine("Cerrando servicio");
            }
            catch
            {
                Console.WriteLine("No se pudo cerrar el servicio");
            }
        }
        private static string getSHA1Hash(string input)
        {
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] data = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }
    }
}
