using ILGPU;
using ILGPU.Runtime;
using System;
using System.IO;
using System.Windows;
using MatrixFFN;
using System.Threading;

namespace ILGPU_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int nummer = 0;
        public double[ ][ ]? eingabeArray;
        public double[ ][ ]? ausgabeArray;
        public FFN? netz;
        //bool weiter = false;
        public FFN_Window netzFenter = new FFN_Window();

        /// <summary>
        /// Hilfsfunktion, die die Parabeltestdaten
        /// generiert.
        /// </summary>
        public void SetzeTestDaten( )
        {
            eingabeArray = new double[ 21 ][ ];
            ausgabeArray = new double[ 21 ][ ];
            for ( int pos = 0; pos < 21; pos++ )
            {
                eingabeArray[ pos ] = new double[ 2 ]
                    { ( pos - 10 ), ( pos - 10 ) };
                ausgabeArray[ ( int ) pos ] = new double[ 1 ]
                    { ( Math.Pow( pos - 10, 2 ) ) };
            }
            
            Anzeige( ArrayToString( eingabeArray) );
            Anzeige( ArrayToString( ausgabeArray) );


        }   // Ende: SetzeTestDaten

        /// <summary>
        /// Hilfsfunktion, die die Datenfelder in einen String schreibt.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Die Daten als String</returns>
        public string ArrayToString( double[ ][ ] data, bool umbruch = false )
        {
            string text = "";
                
            foreach ( double[ ] dat in data )
            {
                text += $" [ {string.Join( ", ", dat ) } ] ";
                if ( umbruch )
                    text += "\n";

            }
            text += "\n";
            return( text );

        }   // Ende: ArrayToString

        /// <summary>
        /// Konstruktor der Klasse
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Test1();

        }   // Ende: MainWindow ( Konstruktor )

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void MenuTest_Click(object sender, RoutedEventArgs e)
        {
            nummer++;
            textBlock.Text += nummer.ToString() + ": SetzeTestDaten().\n";
            SetzeTestDaten();

        }   // Ende: MenuTest_Click

        /// <summary>
        /// Hilfsfunktion, die den übergebenen Text in die 
        /// Textausgabe schreibt.
        /// </summary>
        /// <param name="text">Eingabestring</param>
        public void Anzeige( string? text )
        { 
            if ( !string.IsNullOrEmpty( text ) )
                textBlock.Text += text + "\n"; 
            textScroll.ScrollToBottom();

        }   // Ende: Anzeige

        /// <summary>
        /// Hilfsfunktion, die den übergebenen Text in die 
        /// Textausgabe schreibt.
        /// </summary>
        /// <param name="text">Any-Objekt-Variante</param>
        private void Anzeige( int obj )
        {
            Anzeige( obj.ToString( ) );

        }   // Ende: Anzeige

        /// <summary>
        /// Hilfsfunktion für ILGPU zur Ausgabe der
        /// Systeminformationen.
        /// </summary>
        /// <param name="accelerator">ILGPU-Variable ( GPU bzw. Emulation )</param>
        /// <returns>der Infostring</returns>
        public string GetInfoString( Accelerator accelerator ) 
        { 
            StringWriter stringWriter = new StringWriter();
            accelerator.PrintInformation( stringWriter );
            return( stringWriter.ToString() );
        }   // Ende: GetInfoString
        
        /// <summary>
        /// Gesammelte Werke aus dem ILGPU-Tutorial.
        /// Eröffnen eines Context's und Ausgabe
        /// aller Geräteinformationen.
        /// </summary>
        public void Test1()
        {   // erstes Tutorial etc. 
            using Context context = Context.CreateDefault();

            foreach ( Device dev in context )
            {
                Console.WriteLine( dev );
                Anzeige( dev.ToString() );
                using Accelerator accelerator = dev.CreateAccelerator( context );
                Console.WriteLine( accelerator );
                Anzeige( accelerator.ToString() );
                Console.WriteLine( GetInfoString( accelerator ) );
                Anzeige( GetInfoString( accelerator ) );
            }

        }   // Ende: Test1


        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNladen_Click( object sender, RoutedEventArgs e )
        {
            Anzeige( "FFNladen: " );
            if ( netz == null )
                netz = new FFN( new int [] { 1, 2, 1 }, true );
            netz.LadeDaten( netz.dateiName );


        }   // Ende: FFNladen_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNspeichern_Click( object sender, RoutedEventArgs e )
        {
            Anzeige( "FFNspeichern" );
            netz.SpeicherDaten( netz.dateiName );

        }   // Ende: FFNspeichern_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNinit_Click( object sender, RoutedEventArgs e )
        {
            Anzeige( "FFNinit" );
            int[] topic = new int[] { 2, 40, 20, 10, 1 };
            netz = new FFN( topic, true );
            Anzeige( netz.ToString() );
            //Array.ForEach( )
            //Anzeige( netz.schichtenTopic );
            Array.ForEach( netz.schichtenTopic, Anzeige );
            FFNtrain_1_Click( sender, e );

        }   // Ende: FFNinit_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNtrain_1_Click( object sender, RoutedEventArgs e )
        {
            Anzeige( "Fit'te eine Epoche des Datensatzes..." );
            string result = netz.Fit( eingabeArray, ausgabeArray, 1 );
            Anzeige( result );
            Anzeige( $"Dauer für eine Epoche: { netz.zeitFit }.\n" );
            FFNpredict_Click( sender, e );

        }   // Ende: FFNtrain_1_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNtrain_10_Click( object sender, RoutedEventArgs e )
        {
            Anzeige( "Fit'te 10 Epochen des Datensatzes..." );
            string result = netz.Fit( eingabeArray, ausgabeArray, 10 );
            Anzeige( result );
            Anzeige( $"Dauer für eine Epoche: {netz.zeitFit}.\n" );
            FFNpredict_Click( sender, e );

        }   // Ende: FFNtrain_10_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNtrain_100_Click( object sender, RoutedEventArgs e )
        {
            Anzeige( "Fit'te 10_000 Epochen des Datensatzes..." );
            string result = netz.Fit( eingabeArray, ausgabeArray, 10_000 );
            Anzeige( result );
            Anzeige( $"Dauer für 10_000 Epochen: {netz.zeitFit}.\n" );
            FFNpredict_Click( sender, e );

        }   // Ende: FFNtrain_100_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNpredict_Click( object sender, RoutedEventArgs e )
        {
            Anzeige( "Ergebnisse des Netzwerks sammeln..." );
            var predictArray = new double[ 21 ][];
            for ( int pos = 0; pos < 21; pos++ )
            {
                var ergebnis = netz.Predict( eingabeArray[ pos ] );
                ergebnis[ 0 ] = Math.Round( ergebnis[ 0 ], 2 );
                predictArray[ pos ] = ergebnis;

            }

            Anzeige( ArrayToString( eingabeArray ) );
            Anzeige( ArrayToString( ausgabeArray ) );
            Anzeige( ArrayToString( predictArray ) );

        }   // Ende: FFNpredict_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNlernrate_Click( object sender, RoutedEventArgs e )
        {
            netz.SetzeLernRate( 0.1 );

        }   // Ende: FFNlernrate_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNlernschleife_Click( object sender, RoutedEventArgs e )
        {
            for ( int count = 0; count < 1800; count++ )
            {
                Anzeige( "Fit'te 10_000 Epochen des Datensatzes..." );
                string result = netz.Fit( eingabeArray, ausgabeArray, 10_000 );
                Anzeige( result );
                Anzeige( $"Dauer für 10_000 Epochen: {netz.zeitFit}.\n" );
                Anzeige( "Ergebnisse des Netzwerks sammeln..." );
                var predictArray = new double[ 21 ][];
                for ( int pos = 0; pos < 21; pos++ )
                {
                    var ergebnis = netz.Predict( eingabeArray[ pos ] );
                    ergebnis[ 0 ] = Math.Round( ergebnis[ 0 ], 2 );
                    predictArray[ pos ] = ergebnis;

                }

                Anzeige( ArrayToString( eingabeArray ) );
                Anzeige( ArrayToString( ausgabeArray ) );
                Anzeige( ArrayToString( predictArray ) );
                Thread.Sleep( 500 );

            }   //

        }   // Ende: FFNlernschleife_Click



        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void FFNfensterStart( object sender, RoutedEventArgs e )
        {
            netzFenter.Show();
            netzFenter.Owner = this;

        }   // Ende: FFNfensterStart

        /// <summary>
        /// Aktionen zum Programmende wie z.Bsp.
        /// die Unterfenster zu schließen...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing( object sender, System.ComponentModel.CancelEventArgs e )
        {
            netzFenter.Close();

        }   // Ende: Window_Closing

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void MenuFFNladenVon_Click( object sender, RoutedEventArgs e )
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "FFN"; // Default file name
            dialog.DefaultExt = ".netz"; // Default file extension
            dialog.Filter = "Netzwerkspeicherdatei (.netz)|*.netz"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if ( result == true )
            {
                // Open document
                string filename = dialog.FileName;
                Anzeige( $"Auswahl der Datei {filename}" );

            }

        }   // Ende: MenuFFNladenVon_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void MenuQuit_Click( object sender, RoutedEventArgs e )
        {
            this.Close( );

        }   // Ende: MenuQuit_Click

        /// <summary>
        /// Handlerfunktion -> MenuItem
        /// </summary>
        /// <param name="sender">auslösendes Oberflächenelement</param>
        /// <param name="e">Übergabeparameter davon</param>
        private void MenuFFNspeichernAls_Click( object sender, RoutedEventArgs e )
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "FFN"; // Default file name
            dialog.DefaultExt = ".netz"; // Default file extension
            dialog.Filter = "Netzwerkspeicherdatei (.netz)|*.netz"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if ( result == true )
            {
                // Save document
                string filename = dialog.FileName;
                Anzeige( $"Auswahl der Datei {filename}" );

            }

        }   // Ende: MenuFFNspeichernAls_Click

    }   // Ende: partial class MainWindow

}   // Ende: namespace ILGPU_Test

