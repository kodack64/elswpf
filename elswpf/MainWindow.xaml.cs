using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace elswpf {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Elysium.Controls.Window {
		public class Chamber:INotifyPropertyChanged {
			private int _volume;
			public int volume{
				get{
					return _volume;
				}
				set{
					_volume=value;
					if (_volume < 0) _volume = 0;
					OnPropertyChanged("volume");
				}
			}
			public int brilliance { get; set; }
			public event PropertyChangedEventHandler PropertyChanged;

			protected virtual void OnPropertyChanged(string propertyName) {
				PropertyChangedEventHandler handler = this.PropertyChanged;
				if (handler != null)
					handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		public MainWindow() {
			InitializeComponent();
			this.MouseLeftButtonDown += (sender, e) => this.DragMove();
			DataContext = new Chamber() { volume = 20, brilliance = 10 };
			XmlDocument xml = new XmlDocument();
		}
		private void TabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			if (DataContext != null) {
				Chamber ch = (Chamber)DataContext;
				Debug.WriteLine(ch.volume);
			}
		}
		private static readonly string Windows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
		private static readonly string SegoeUI = Windows + @"\Fonts\SegoeUI.ttf";
		private static readonly string Verdana = Windows + @"\Fonts\Verdana.ttf";
		private static readonly string MSGothic = Windows + @"\Fonts\msgothic.ttc";
		private void AccentGlyphInitialized(object sender, EventArgs e) {
			AccentGlyph.FontUri = new Uri(File.Exists(SegoeUI) ? SegoeUI : Verdana);
		}
		private void ChamberGlyphInitialized(object sender, EventArgs e) {
			ChamberGlyph.FontUri = new Uri(MSGothic);
		}
	}
}
