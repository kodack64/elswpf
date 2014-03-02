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
using System.IO;

namespace elswpf {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Elysium.Controls.Window {
		public MainWindow() {
			InitializeComponent();
			this.MouseLeftButtonDown += (sender, e) => this.DragMove();
		}
		private void TabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
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
