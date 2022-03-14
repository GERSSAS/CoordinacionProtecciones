using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Neplan_coordinacion.NeplanService;
using System.Xml;
using _Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace Neplan
{
    public partial class FormCoordinacionProtecciones : Form
    {
        public FormCoordinacionProtecciones()
        {
            InitializeComponent();
        }

        #region Variables Gloabales

        Webservice webservice = new Webservice();
        ExternalProject proyecto = new ExternalProject();
        ExternalProject proyectoVariante = new ExternalProject();
        NeplanServiceClient nepService = FormLogin.nepService;
        Dictionary<string, string> elementNames = new Dictionary<string, string>();
        Dictionary<string, string> elementTypes = new Dictionary<string, string>();
        Dictionary<string, string> lineaNames = new Dictionary<string, string>();//En este diccionario se guardará la información relacionada con los nombres de las lines del proyecto
        Dictionary<string, string> lineaTypes = new Dictionary<string, string>();//En este diccionario se guardará la información relacionada con el tipo de las lines del proyecto
        Dictionary<string, string> trans2DNames = new Dictionary<string, string>();//En este diccionario se guardará la información relacionada con los nombres de los transformadores de 2 devanados del proyecto
        Dictionary<string, string> trans2DTypes = new Dictionary<string, string>();//En este diccionario se guardará la información relacionada con el tipo de los transformadores de 2 devanados del proyecto
        Dictionary<string, string> trans3DNames = new Dictionary<string, string>();//En este diccionario se guardará la información relacionada con los nombres de los transformadores de 3 devanados del proyecto
        Dictionary<string, string> trans3DTypes = new Dictionary<string, string>();//En este diccionario se guardará la información relacionada con el tipo de los transformadores de 3 devanados del proyecto
        
        List<string> nomElementSel = new List<string>();
        List<string> typeElementSel = new List<string>();

        IEnumerable<ShortCircuitLocation> ubucacioncorto;

        List<string> NombreElementoR = new List<string>();
        List<string> TipoElementoR = new List<string>();
        List<string> Puerto0ElementoR = new List<string>();
        List<string> Puerto1ElementoR = new List<string>();
        List<string> tipoDeFallaEnCorto = new List<string>();
        List<double> distanciadeFallo = new List<double>();
        List<string> impedanciaDeCorto = new List<string>();

        public int ConteoResultado = 5;//aqui empieza a cargarse el numero de la fila  para cargar el archivo
        string Tipo_Elemento = "";   // Variable donde se va guardar el resultado para exportarlo a Excel
        string Tipo_Falla = "";  // Variable donde se va guardar el resultado para exportarlo a Excel
        bool errorResults;
        int contadorAnalisis = 0;
        int totalAnalisis = 0;
        #endregion

        #region BOTON CARGAR PROYECTO
        private void button1_Click(object sender, EventArgs e)
        {
            /* incia servicio de Neplan*/
            var neplan = webservice.nepService;
            /* valida que el campo donde va el nombre del proyecto no este vacio */

            if (txtProyecto.Text == "")
            {
                MessageBox.Show("Por favor, ingrese el nombre del proyecto");
                txtProyecto.Focus();
                return;
            }
            else //si el objeto proyecto de Neplan, no esta vacio, el nombre del proyecto no esta vacio, muestra mensaje para volver a obtener mensaje
            {
                if (proyecto != null && proyecto.ProjectName != null)
                {
                    StringComparer compararNombres = StringComparer.OrdinalIgnoreCase;
                    /* si el nombre del proyecto es diferente a el de la caja de texto, y el nombre del proyecto es diferente de nulo, muestra mensaje para que se limpien los campos */
                    if (compararNombres.Compare(proyecto.ProjectName, txtProyecto.Text) == 0)
                    {
                        MessageBox.Show("El proyecto ya ha sido Obtenido, clic en limpiar para obtener de nuevo el proyecto");
                        txtProyecto.Focus();
                        return;
                    }
                    if (compararNombres.Compare(proyecto.ProjectName, txtProyecto.Text) != 0 && proyecto.ProjectName != null)
                    {
                        MessageBox.Show("Presione clic en el botom limpiar para obtener un nuevo proyecto");
                        txtProyecto.Focus();
                        return;
                    }
                }
                else // si el objeto proyecto de Neplan esta vacio, ejecuta la funcion GetProject con el nombre ingresado por el usuario
                {   // si el campo de variante no esta vacio, toma la variante del proyecto, de lo contrario, solo toma el proyecto sin variante
                    if (textVariante.Text != "")
                    {
                        proyecto = neplan.GetProject(txtProyecto.Text, textVariante.Text, null, null);
                    } else { proyecto = neplan.GetProject(txtProyecto.Text, null, null, null); }

                        

                    if (proyecto == null)// si el servidor devuelve null, significa que no existe el proyecto en la base de datos
                    {
                        MessageBox.Show("El nombre del proyecto no se encuentra en la base de datos");
                        txtProyecto.Focus();
                        return;
                    }
                    else//Entonces si existe el proyecto, obtengo todos nombres y tipos de todos los elementos
                    {
                       
                        neplan.GetAllElementsOfProject(proyecto, ref elementNames, ref elementTypes);// Obtengo elementos

                        /* Obtengo los elementos del proyecto y los despliego en el combo box que contiene los elementos en falla*/
                        int contEleNam = 0;
                        int contEleTyp = 0;

                        foreach (var item in elementNames)
                        {
                            dgvElements1.Rows.Add();
                            dgvElements1[1, contEleNam].Value = item.Value;
                            dgvElements1[3, contEleNam].Value = item.Key;
                            contEleNam++;

                        }
                        foreach (var item in elementTypes)
                        {
                            dgvElements1[2, contEleTyp].Value = item.Value;
                            if (item.Value == "Line"  || item.Value == "Busbar")
                            {
                                contEleTyp++;
                            }
                            else
                            {
                                dgvElements1.Rows.RemoveAt(contEleTyp);
                            }
                        }

                        int contEleNam2 = 0;
                        int contEleTyp2 = 0;
                        foreach (var item in elementNames)
                        {
                            dgvElements2.Rows.Add();
                            dgvElements2[1, contEleNam2].Value = item.Value;
                          
                            contEleNam2++;

                        }
                        foreach (var item in elementTypes)
                        {
                            dgvElements2[2, contEleTyp2].Value = item.Value;
                            if (item.Value == "Line" || item.Value == "Trafo2Winding" || item.Value == "Trafo3Winding" || item.Value == "CircuitBreaker")
                            {
                                contEleTyp2++;
                            }
                            else
                            {
                                dgvElements2.Rows.RemoveAt(contEleTyp2);
                            }
                        }

                        /*  obtengo las lineas y transformadores del proyecto y los despliego en el combox 2, donde se seleccionan los elementos en falla*/
                        

                        MessageBox.Show("EL PROYECTO " + txtProyecto.Text + " FUE CARGADO CON EXITO");
                    }
                }
            }
        }
        #endregion
        Timer timer2 = new Timer
        {
            Interval = 1000
        };
        

        ShortCircuitLineLocation LineaACorto = new ShortCircuitLineLocation { };
        ShortCircuitLocation NodoACorto = new ShortCircuitLineLocation { };
        string[] NombreNodo = new string[100];
        ShortCircuitLineLocation[] milineacorto = new ShortCircuitLineLocation[1];

        #region BOTON ANALIZAR
        private void button2_Click(object sender, System.EventArgs e)
        {
            var neplan = webservice.nepService;
            int cont2 = 0;
            List<string> nomElementSel2 = new List<string>();

            /* cuenta los elementos selecionados para falla de corto */
            foreach (DataGridViewRow row in dgvElements1.Rows)
            {
                

                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        nomElementSel2.Add(row.Cells[1].Value.ToString());
                        cont2++;
                    }
                
            }

            /* si hay un elemento seleccionado, ejecuta este codigo, de lo contrario muestra mensaje de error */
            if (cont2 != 0)
            {
                /* funcion para quitar todos los elementos en corto del proyecto */
                quitarElementosCorto(proyecto);

                /* obtiene los elementos en corto */
                ubucacioncorto = neplan.GetShortCircuitLocations(proyecto);//En esta parte se verifica que el proyecto no tenga otros elementos en corto

                /* si no hay elementos en corto, procede a ejecutar el siguiente codigo */
                if (ubucacioncorto.Count() == 0)
                {
                    int cont3 = 0;
                    List<string> nomElementResult = new List<string>();
                    /* para cada elemento selecionado en el combobox de elementos para ver resultados, ejecuta este codigop */
                    foreach (DataGridViewRow row in dgvElements2.Rows)
                    {
                        
                            /* si el elemento esta selecionado, lo añade a la lsita nomElementResult*/
                            if (Convert.ToBoolean(row.Cells[0].Value) == true)
                            {
                                nomElementResult.Add(row.Cells[1].Value.ToString());
                                cont3++;
                            }
                       

                    } /* si hay elementos selecionados, procede a ejecutar la funcion, realizarAnalisis, de lo contrario muestra mensaje en pantalla */
                    if (cont3 != 0)
                    {
                        //realizarAnalisis();
                        //Thread analizar = new Thread(() => realizarAnalisis());
                        //analizar.Start();
                       
                        realizarAnalisis();
                     
                    }
                    else
                    {
                        MessageBox.Show("NO SE HA SELECCIONADO NINGÚN ELEMENTO PARA EXPORTAR LOS RESULTADOS DEL ANÁLISIS  DE CORTOCIRCUITO");
                    }
                }
                else
                {
                    MessageBox.Show("EL PROYECTO YA TIENE ELEMENTOS EN CORTOCIRCUITOS. DESACTIVE LOS ELEMENTOS Y GRABE EL PROYECTO NUEVAMENTE ");//realizarAnalisis();
                }
            }
            else
            {
                MessageBox.Show("NO SE HA SELECCIONADO NINGÚN ELEMENTO EN FALLA");
            }
        }

        private void quitarElementosCorto(ExternalProject proyectoaFiijar)
        {
            var neplan = webservice.nepService;
            
            ShortCircuitLineLocation NodosACorto = new ShortCircuitLineLocation { };
            ShortCircuitLineLocation[] milineacorto = new ShortCircuitLineLocation[1];
            int x = 0;
            int y = 0;

            foreach (var item in elementTypes)
            {
                if (item.Value == "Busbar" || item.Value == "Line")
                {
                   x++;
                }
            }

            ShortCircuitLineLocation[] milineaw = new ShortCircuitLineLocation[x];
            foreach (var item in elementTypes)
            {
                        if (item.Value == "Busbar" || item.Value == "Line")
                        {
                            NodosACorto = new ShortCircuitLineLocation { ElementID = Guid.Parse(item.Key), IsFaultLocation = false };
                            milineaw[y] = NodosACorto;
                            y++;
                        }                   
                
            }

            ReturnCode fijardistancia = neplan.SetShortCircuitLocations(proyectoaFiijar, milineaw);
        }
        #endregion

        #region FUNCION ANALIZAR
        int cont = 0;
        int contElementoR = 0;
        List<Guid> idElements = new List<Guid>();
        



       
        private void realizarAnalisis()
        {
            MiLoading.Enabled = true;
            MiLoading.Visible = true;
            
            var neplan = webservice.nepService;

            List<Guid> allNodos = new List<Guid>();

            /*-- Obtengo los elementos seleccionados para ubicar las fallas y agrego el id a la lista "idElements" --*/
            foreach (DataGridViewRow row in dgvElements1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    idElements.Add(Guid.Parse(row.Cells[3].Value.ToString()));
                    nomElementSel.Add(row.Cells[1].Value.ToString());
                    typeElementSel.Add(row.Cells[2].Value.ToString());
                    cont++;
                }
            }
            int contElementoR = 0;

            /*-- Obtengo los elementos seleccionados y agrego el id a la lista "idElements" --*/
            foreach (DataGridViewRow row2 in dgvElements2.Rows)
            {
                if (Convert.ToBoolean(row2.Cells[0].Value) == true)
                {
                    NombreElementoR.Add(row2.Cells[1].Value.ToString());
                    TipoElementoR.Add(row2.Cells[2].Value.ToString());
                    contElementoR++;
                }
            }
            contarTotalAnalisis();
            // EN ESTE PUNTO SE CARLAS LOS VALORES DE LAS LISTAS
            tipoDeFallaEnCorto.Clear();
            tipoDeFallaEnCorto.Add("0");// trifasica
            tipoDeFallaEnCorto.Add("1"); // monofasica
            tipoDeFallaEnCorto.Add("2"); // bifasica
            tipoDeFallaEnCorto.Add("3"); // bifasica a tierra
            distanciadeFallo.Clear();
            distanciadeFallo.Add(2);
            distanciadeFallo.Add(50);
            distanciadeFallo.Add(98);
            impedanciaDeCorto.Clear();
            
            impedanciaDeCorto.Add(t_Resistencia1.Text);
            impedanciaDeCorto.Add(t_Resistencia2.Text.ToString());
            impedanciaDeCorto.Add(t_Resistencia3.Text.ToString());
            impedanciaDeCorto.Add(t_Resistencia4.Text.ToString());
            
            //EN ESTE PUNTO SE ABRE EL ARCHIVO EXCEL
            _Excel.Application oApp;
            _Excel.Worksheet oSheet;
            _Excel.Workbook oBook;

          
            oApp = new _Excel.Application();
            oBook = oApp.Workbooks.Add();
            oSheet = (_Excel.Worksheet)oBook.Worksheets.get_Item(1);
            oApp.Visible = false;
            /* codigo para obtener el id del excel recien creado, esto para luego cerrar ese proceso al terminar de escribir en el excel */
            titulosExcel2(ConteoResultado, ref oSheet);
            HandleRef hwnd = new HandleRef(oApp, (IntPtr)oApp.Hwnd);
            int pid = -1;
            int xPid;
            xPid = GetWindowThreadProcessId(hwnd, out pid); 

            //EN ESTE PUNTO SE RALIZÁN LOS ANALISIS  DE CORTOCIRCUITO
            foreach (var itemTypes in elementTypes)
            {
                if (itemTypes.Value == "Line" || itemTypes.Value == "Busbar")
                {
                    foreach (var itemName in elementNames)
                    {
                        Tipo_Elemento = itemTypes.Value;//se guarda el tipo de elemento para exportar a Excel

                        if (itemTypes.Key == itemName.Key)
                        {
                            foreach (var itemSeleccionado in idElements)
                            {
                                if (itemSeleccionado.ToString() == itemName.Key.ToString())
                                {
                                    foreach (var itemTipoDeFalla in tipoDeFallaEnCorto)
                                    {
                                        //se guarda el nombre del tipo de falla para exportar a Excel
                                        if (itemTipoDeFalla == "0") { Tipo_Falla = "TRIFASICO";}
                                        if (itemTipoDeFalla == "1") { Tipo_Falla = "MONOFASICO";}
                                        if (itemTipoDeFalla == "2") { Tipo_Falla = "BIFASICO";}
                                        if (itemTipoDeFalla == "3") { Tipo_Falla = "BIFASICO_TIERRA";}

                                        foreach (var itemImpedancia in impedanciaDeCorto)
                                        {
                                            neplan.SetCalcParameterAttribute(proyecto, "ShortCircuit", "FaultType", itemTipoDeFalla);//Se selcciona el tipo de falla
                                            neplan.SetCalcParameterAttribute(proyecto, "ShortCircuit", "RArc", itemImpedancia);//Se selcciona la impedancia de falla

                                            if (itemTypes.Value == "Line"){

                                                foreach (var itemDistanciaDeFallo in distanciadeFallo)
                                                {
                                                    LineaACorto = new ShortCircuitLineLocation { ElementID = Guid.Parse(itemName.Key), IsFaultLocation = true, Distance = itemDistanciaDeFallo };
                                                    /* se crea esta variable para fijar el elemento a falla de corto */
                                                    ShortCircuitLineLocation[] milineaw = new ShortCircuitLineLocation[1];

                                                    
                                                    milineaw[0] = LineaACorto;
                                                    ReturnCode fijarLineaEnCorto = neplan.SetShortCircuitLocations(proyecto, milineaw);

                                                    //tring[] networkresultsSC = neplan.GetListResultSummary(proyecto, "ShortCircuit", new DateTime(), networkTypeGroupSC, null);
                                                    AnalysisReturnInfo analysis2 = neplan.AnalyseVariant(proyecto, Guid.NewGuid().ToString(), "ShortCircuit", "Default", string.Empty, string.Empty, string.Empty);
                                                    contadorAnalisis++;
                                                    label11.Text = contadorAnalisis.ToString() + " Resultados de " + totalAnalisis.ToString() + " totales";
                                                    if (analysis2.ReturnInfo == 1)//Verifica que el corto se ejecute corectamente
                                                    {
                                                        for (int fila = 0; fila < NombreElementoR.Count; fila++)
                                                        {
                                                            string NombreElemento = NombreElementoR[fila];
                                                            string TipoElemento = TipoElementoR[fila];
                                                            
                                                            int portNr = 0;// 0:para el primer puerto del elemento
                                                            
                                                            
                                                            //obtiene los resultados del elemento para la cuadrícula externa

                                                            //neplan.GetElementAttributes(proyecto);
                                                            string resultadoSC1 = neplan.GetResultElementByName(proyecto, NombreElemento, TipoElemento, portNr, "ShortCircuit", null);
                                                            /* exporta los resultados a la funcion exportarExcel2 para escribir en la hoja de excel */
                                                            exportarExcel2(ConteoResultado, ref oSheet, itemName.Value, Tipo_Elemento, Tipo_Falla, itemImpedancia, itemDistanciaDeFallo, portNr, resultadoSC1, NombreElemento);
                                                            ConteoResultado++;
                                                            
                                                            portNr = 1;
                                                            
                                                            /* obtiene los resultados para el puerto 1, y exporta los resultados a exportarExcel2 para escribir en el excel */
                                                            resultadoSC1 = neplan.GetResultElementByName(proyecto, NombreElemento, TipoElemento, portNr, "ShortCircuit", null);
                                                            exportarExcel2(ConteoResultado, ref oSheet, itemName.Value, Tipo_Elemento, Tipo_Falla, itemImpedancia, itemDistanciaDeFallo, portNr, resultadoSC1, NombreElemento);
                                                            ConteoResultado++;
                                                            

                                                            if (TipoElemento == "Trafo3Winding") {
                                                                portNr = 2;
                                                                resultadoSC1 = neplan.GetResultElementByName(proyecto, NombreElemento, TipoElemento, portNr, "ShortCircuit", null);
                                                                exportarExcel2(ConteoResultado, ref oSheet, itemName.Value, Tipo_Elemento, Tipo_Falla, itemImpedancia, itemDistanciaDeFallo, portNr, resultadoSC1, NombreElemento);
                                                                ConteoResultado++;
                                                                

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("¡No se pudo correr el Cortocircuito!");

                                                    }
                                                    /* quita la falla de corto para el elemento seleccionado */
                                                    LineaACorto = new ShortCircuitLineLocation { ElementID = Guid.Parse(itemName.Key), IsFaultLocation = false, Distance = itemDistanciaDeFallo };
                                                    milineaw[0] = LineaACorto;
                                                    ReturnCode fijarLineaEnCorto2 = neplan.SetShortCircuitLocations(proyecto, milineaw);
                                                }

                                            }
                                            else
                                            {
                                                ShortCircuitLocation[] minodo = new ShortCircuitLocation[1];
                                                NodoACorto = new ShortCircuitLocation { ElementID = Guid.Parse(itemName.Key), IsFaultLocation = true };

                                                minodo[0] = NodoACorto;
                                                ReturnCode fijarNodoEnCorto = neplan.SetShortCircuitLocations(proyecto, minodo);

                                                AnalysisReturnInfo analysis2 = neplan.AnalyseVariant(proyecto, Guid.NewGuid().ToString(), "ShortCircuit", "Default", string.Empty, string.Empty, string.Empty);
                                                contadorAnalisis++;
                                                label11.Text = contadorAnalisis.ToString() + " Resultados de " + totalAnalisis.ToString() + " totales";
                                                if (analysis2.ReturnInfo == 1)//Verifica que el corto se ejecute corectamente
                                                {
                                                    for (int fila = 0; fila < NombreElementoR.Count; fila++)
                                                    {
                                                        string NombreElemento = NombreElementoR[fila];
                                                        string TipoElemento = TipoElementoR[fila];
                                                        
                                                        int portNr = 0;// 0:para el primer puerto del elemento


                                                        //obtiene los resultados del elemento para la cuadrícula externa

                                                        //neplan.GetElementAttributes(proyecto);
                                                        string resultadoSC1 = neplan.GetResultElementByName(proyecto, NombreElemento, TipoElemento, portNr, "ShortCircuit", null);
                                                        /* exporta los resultados a la funcion exportarExcel2 para escribir en la hoja de excel */
                                                        exportarExcel2(ConteoResultado, ref oSheet, itemName.Value, Tipo_Elemento, Tipo_Falla, itemImpedancia, 0, portNr, resultadoSC1, NombreElemento);
                                                        
                                                        ConteoResultado++;

                                                        portNr = 1;

                                                        /* obtiene los resultados para el puerto 1, y exporta los resultados a exportarExcel2 para escribir en el excel */
                                                        resultadoSC1 = neplan.GetResultElementByName(proyecto, NombreElemento, TipoElemento, portNr, "ShortCircuit", null);
                                                        exportarExcel2(ConteoResultado, ref oSheet, itemName.Value, Tipo_Elemento, Tipo_Falla, itemImpedancia, 0, portNr, resultadoSC1, NombreElemento);
                                                        ConteoResultado++;
                                                        

                                                        if (TipoElemento == "Trafo3Winding")
                                                        {
                                                            portNr = 2;
                                                            resultadoSC1 = neplan.GetResultElementByName(proyecto, NombreElemento, TipoElemento, portNr, "ShortCircuit", null);
                                                            exportarExcel2(ConteoResultado, ref oSheet, itemName.Value, Tipo_Elemento, Tipo_Falla, itemImpedancia, 0, portNr, resultadoSC1, NombreElemento);
                                                            ConteoResultado++;
                                                            

                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("¡No se pudo correr el Cortocircuito!");

                                                }

                                                
                                                NodoACorto = new ShortCircuitLocation { ElementID = Guid.Parse(itemName.Key), IsFaultLocation = false };

                                                minodo[0] = NodoACorto;
                                                ReturnCode fijarNodoEnCorto2 = neplan.SetShortCircuitLocations(proyecto, minodo);

                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            MiLoading.Visible = false;

            if (errorResults == true)
            {
                MessageBox.Show("HUBO UN ERROR AL OBTENER RESULTADOS DE CORTO");
            }
            else { MessageBox.Show("SE EJECUTÓ EL ANÁLISIS  DE CORTO EXITOSAMENTE"); }
            

            /* string para guardar la ubicacion donde se va a guardar el excel */
            string savePath = "";
            /* objeto para mostrar mensaje en pantalla donde se va a guardar el archivo */
            SaveFileDialog sf = new SaveFileDialog();
            
            sf.DefaultExt = "xlsx";
            sf.RestoreDirectory = true;
            /* si el usuari selecciona la carpeta donde va a guardar el excel, se guarda la ubicacion en la variable savePath */
            if (sf.ShowDialog() == DialogResult.OK)
            {
                savePath = sf.FileName;
            }


            /* guarda el archivo de excel creado */
            oBook.SaveAs(savePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            oBook.Close();
            oApp.Quit();

            /* obtiene todos los proceos de EXCEL abiertos en el sistema */
            System.Diagnostics.Process[] AllProcesses = System.Diagnostics.Process.GetProcessesByName("EXCEL");

            /* para cada proceso de excel abiert, ejecuta este codigo */
            foreach (System.Diagnostics.Process process in AllProcesses)
            { /* si id del proceso de excel, es el mismo id del proceso de excel donde guardamos los resultados del analisis, mata el proceso */
                if (process.Id == pid)
                { 
                    process.Kill();
                }
            }
            
        }
        #endregion




        
        private void contarTotalAnalisis() {

            int contadorLineas = 0;
            int contadorNodos = 0;
            
            foreach (var itemTypes in elementTypes)
            {
                if (itemTypes.Value == "Line" || itemTypes.Value == "Busbar")
                {
                    foreach (var itemSeleccionado in idElements)
                    {
                        if (itemSeleccionado.ToString() == itemTypes.Key.ToString())
                        {
                            if (itemTypes.Value == "Line")
                            {
                                contadorLineas++;
                            }
                            else {
                                contadorNodos++;
                            }
                        }
                    }
                }
            }

            totalAnalisis =  ((contadorLineas*48) + (contadorNodos*16)) ;
          
            return ; 
        }
            /* funcion para obtener el id del proceso de excel que creamos para guardar los resultados */
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(HandleRef excel, out int processId);

        #region Boton Limpiar
        private void button5_Click(object sender, EventArgs e)
        {
            //Reiniciar cont1, tabla de resultados
            //Limpiar tabla 1
            dgvElements1.Rows.Clear();
            dgvElements1.Refresh();
            dgvElements2.Rows.Clear();
            dgvElements2.Refresh();
            ubucacioncorto = null;
            proyecto = null;
            
        }
        #endregion
        
        #region Boton EXPORTAR
        private void titulosExcel2(int fila, ref _Excel.Worksheet hoja)
        {
            _Excel.Range rango;
            //hoja.Cells[1, 1] = "Creación de base de datos cortocircuito";//Se crea el titulo de la hoja
            hoja.Cells[4, 1] = "Elemento falla";
            hoja.Cells[4, 2] = "Tipo Elemento";
            hoja.Cells[4, 3] = "Tipo Falla";
            hoja.Cells[4, 4] = "Ohm Falla";
            hoja.Cells[4, 5] = "% ubicación";
            hoja.Cells[4, 6] = "Nombre Elemento";
            hoja.Cells[4, 7] = "Puerto Elemento";
            hoja.Cells[4, 8] = "Direccion";
            hoja.Cells[4, 9] = "IK2L1";
            hoja.Cells[4, 10] = "IK2L2";
            hoja.Cells[4, 11] = "IK2L3";
            hoja.Cells[4, 12] = "I3I0";

            //Se incluye los valores de los elementos donde se depositaran los resultados de corto que se van a colocar la tabla de resultados
            for (int fila2 = 0; fila2 < NombreElementoR.Count; fila2++)
            {
                hoja.Cells[1, fila2 + 1] = NombreElementoR[fila2];
                hoja.Cells[2,fila2 + 1] = TipoElementoR[fila2];
            }
            
            //Se incluye los valores de las resistencias en la tabla de resultados
            int contt = 1;
            foreach(var resistencia in impedanciaDeCorto)
            {
                hoja.Cells[3,contt] = resistencia;
                contt++;
            }

            //Se incluye los valores de los elementos en falla en la tabla de resultados
            for (int fila2 = 0; fila2 < nomElementSel.Count; fila2++)
            {
                hoja.Cells[fila2+5, 18] = nomElementSel[fila2];
                hoja.Cells[fila2+5, 19] = typeElementSel[fila2];
            }

            //PONER BORDE A LA CELDA
            rango = hoja.Range["A4", "L4"];
            rango.Borders.LineStyle = _Excel.XlLineStyle.xlContinuous;

            //modificamos los anchos de las colunnas
            rango = hoja.Columns[1];
            rango.ColumnWidth = 30;
            rango = hoja.Columns[2];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[3];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[4];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[5];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[6];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[7];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[8];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[9];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[10];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[10];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[11];
            rango.ColumnWidth = 20;
            rango = hoja.Columns[12];
            rango.ColumnWidth = 20;
        }

        public void exportarExcel2(int fila, ref _Excel.Worksheet hoja, string dato1, string dato2, string dato3, string dato4, double dato5, int puerto,string resultado,string dato6)
        {

            hoja.Cells[fila, 1] = dato1;//Elemento en falla
            hoja.Cells[fila, 2] = dato2;//Tipo Elemento en falla
            hoja.Cells[fila, 3] = dato3;//Tipo Falla
            hoja.Cells[fila, 4] = dato4;//Ohm Falla
            hoja.Cells[fila, 5] = dato5;//% ubicación de la falla
            hoja.Cells[fila, 6] = dato6;//Metodo para obtener el nombre donde se quiere ver los resultados de la corriente
            hoja.Cells[fila, 7] = puerto;//Puerto donde se analizará los resultados de las corrientes
            hoja.Cells[fila, 8] = GetXMLAttributeFaultedirection(resultado, dato6);//Metodo para obtener la direccion de la corrinete
            hoja.Cells[fila, 9] = GetXMLAttributeIk2L1(resultado);//Metodo para obtener los resultados de la corriente
            hoja.Cells[fila, 10] = GetXMLAttributeIk2L2(resultado);//Metodo para obtener los resultados de la corriente
            hoja.Cells[fila, 11] = GetXMLAttributeIk2L3(resultado);//Metodo para obtener los resultados de la corriente
            hoja.Cells[fila, 12] = GetXMLAttributeI3I0(resultado);//Metodo para obtener los resultados de la corriente
            hoja.Cells[fila, 17] = dato1 + dato2 + dato3 + dato4 + dato5 + dato6 + puerto;
        }


        #endregion

        #region CONVERTIR LOS VALORES DE XML


    //Metodo para encapsular los resultados del cortocircuito Ik2L1
    private string GetXMLAttributeIk2L1(string result)
        {
            string rpta = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(result);
                XmlNodeList elemList = doc.GetElementsByTagName("Ik2L1");
                for (int i = 0; i < elemList.Count; i++)
                {
                    rpta = elemList[i].InnerXml;
                }
                return rpta;
            } catch {
                return "error";
            }
        }

        //Metodo para encapsular los resultados del cortocircuito Ik2L2
        private string GetXMLAttributeIk2L2(string result)
        {
            string rpta = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(result);
                XmlNodeList elemList = doc.GetElementsByTagName("Ik2L2");
                for (int i = 0; i < elemList.Count; i++)
                {
                    rpta = elemList[i].InnerXml;
                }
                return rpta;
            }
            catch {
                return "error";
            }
        }
        //Metodo para encapsular los resultados del cortocircuito Ik2L3
        private string GetXMLAttributeIk2L3(string result)
        {
            string rpta = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(result);
                XmlNodeList elemList = doc.GetElementsByTagName("Ik2L3");
                for (int i = 0; i < elemList.Count; i++)
                {
                    rpta = elemList[i].InnerXml;
                }
                return rpta;
            }
            catch { return "error";
            }
        }
        //Metodo para encapsular los resultados del cortocircuito I3I0
        private string GetXMLAttributeI3I0(string result)
        {
            string rpta = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(result);
                XmlNodeList elemList = doc.GetElementsByTagName("I3I0");
                for (int i = 0; i < elemList.Count; i++)
                {
                    rpta = elemList[i].InnerXml;
                }
                return rpta;
            }
            catch {
                return "error";
            }
        }
        //Metodo para encapsular los resultados del cortocircuito nodo de falla
        private string GetXMLAttributeFaultedNode(string result)
        {
            string rpta = "";
            XmlDocument doc = new XmlDocument();
            try
            {

            doc.LoadXml(result);
            XmlNodeList elemList = doc.GetElementsByTagName("FaultedNode");
            
                for (int i = 0; i < elemList.Count; i++)
                {
                    rpta = elemList[i].InnerXml;
                }
                return rpta;
            }
            catch (Exception ex) {

                return "error";
            }
        }
        //Metodo para encapsular los resultados del cortocircuito direccion de falla
        private string GetXMLAttributeFaultedirection(string result, string elemento)
        {
            string rpta = "";
            XmlDocument doc = new XmlDocument();
            
            try
            {
                doc.LoadXml(result);
                XmlNodeList elemList = doc.GetElementsByTagName("FaultDirection");
                for (int i = 0; i < elemList.Count; i++)
                {
                    rpta = elemList[i].InnerXml;
                }
                return rpta;
            }
            catch (Exception ex)
            {
                errorResults = true;
                return "error";
            }
        }
        #endregion

        #region CAMPOS PARA BUSCAR ELEMENTOS

        /* funcion para buscar un elemento en el comboox de elementos en corto */
        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            /* si el cambo de texto de buscar es diferente de vacio, ejecuta el siguiente codigo */
            if (txtSearch1.Text != "")
            {
                
                dgvElements1.CurrentCell = null;
                /* vuelve no visible cada elemento en el combobox */
                foreach (DataGridViewRow Row in dgvElements1.Rows)
                {
                    Row.Visible = false;
                }
                /*  para cada elemento en el combobox, ejecuta el siguiente codigo*/
                foreach (DataGridViewRow Row in dgvElements1.Rows)
                {

                    foreach (DataGridViewCell c in Row.Cells)
                    { /* si el valor de la celda es diferente de nulo, ejecuta este codigo  */
                        if (c.Value != null)
                        {
                            /* busca el texto ingresado en el campo buscar y lo compara con el texto de la celda, si lo encuentra, hace visible la celda */
                            if ((c.Value.ToString().ToUpper()).IndexOf(txtSearch1.Text.ToUpper()) == 0)
                            {
                                Row.Visible = true;
                                break;
                            }
                        }

                    }
                }
            } /* si el campo de texto de busqueda es igual a vacio, hace visible todas las celdas */
            else
            {
                foreach (DataGridViewRow Row in dgvElements1.Rows)
                {
                    Row.Visible = true;
                }
            }

        }

        private void textSearch2_TextChanged(object sender, EventArgs e)
        {
            if (textSearch2.Text != "")
            {
                dgvElements2.CurrentCell = null;
                foreach (DataGridViewRow Row in dgvElements2.Rows)
                {
                    Row.Visible = false;
                }
                foreach (DataGridViewRow Row in dgvElements2.Rows)
                {
                    foreach (DataGridViewCell c in Row.Cells)
                    {
                        if (c.Value != null)
                        {
                            if ((c.Value.ToString().ToUpper()).IndexOf(textSearch2.Text.ToUpper()) == 0)
                            {
                                Row.Visible = true;
                                break;
                            }
                        }

                    }
                }
            }
            else
            {
                foreach (DataGridViewRow Row in dgvElements2.Rows)
                {
                    Row.Visible = true;
                }
            }

        }


        #endregion



       
       
    }
}

