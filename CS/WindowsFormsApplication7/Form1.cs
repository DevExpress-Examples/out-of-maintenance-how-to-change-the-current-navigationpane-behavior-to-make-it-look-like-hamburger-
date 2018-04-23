using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;

namespace HamburgerMenu {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            navigationPane1.PageProperties.ShowMode = ItemShowMode.Image;
            navigationPane1.StateChanged += navigationPane1_StateChanged;
            CustomNavigationButton button = new CustomNavigationButton(navigationPane1);
            ButtonsPanel buttonPanel = (navigationPane1 as INavigationPane).ButtonsPanel as ButtonsPanel;
            buttonPanel.Buttons.Insert(0, button);

            for (int i = 0; i < buttonPanel.Buttons.Count; i++)
                ((NavigationButton)buttonPanel.Buttons[i]).VisibleIndex = i;                       

            buttonPanel.ButtonClick += ButtonsPanel_ButtonClick;
        }

        void navigationPane1_StateChanged(object sender, StateChangedEventArgs e) {
            NavigationPane navPane = sender as NavigationPane;

            if (e.State == NavigationPaneState.Collapsed) {
                navPane.PageProperties.ShowMode = ItemShowMode.Image;
                navPane.LayoutChanged();
                Size newSize = (navPane as INavigationPane).RegularMinSize;
                navPane.Width = newSize.Width - NavigationPane.StickyWidth;
            }
        }
        void ButtonsPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e) {
            NavigationPaneButtonsPanel panel = sender as NavigationPaneButtonsPanel;
            NavigationPane navPane = panel.Owner as NavigationPane;

            if (navPane.State == NavigationPaneState.Collapsed)
            {
                navPane.State = NavigationPaneState.Default;
                return;
            }
            if (navPane.PageProperties.ShowMode == ItemShowMode.Image)
                navPane.PageProperties.ShowMode = ItemShowMode.ImageAndText;
            else
                navPane.PageProperties.ShowMode = ItemShowMode.Image;
        }
    }
    public class CustomNavigationButton : NavigationButton {
        NavigationPane paneCore;
        public CustomNavigationButton(NavigationPane navigationPane)
            : base(navigationPane.SelectedPage) {
            paneCore = navigationPane;
        }
        public override bool UseCaption {
            get {
                return paneCore.PageProperties.ShowMode == ItemShowMode.ImageAndText ||
                    paneCore.PageProperties.ShowMode == ItemShowMode.Text ||
                    ((paneCore.PageProperties.ShowMode == ItemShowMode.ImageOrText || paneCore.PageProperties.ShowMode == ItemShowMode.Default) & Image == null);
            }
        }
        public override bool UseImage {
            get { return paneCore.PageProperties.ShowMode != ItemShowMode.Text; }
        }
        public override ButtonStyle Style {
            get { return ButtonStyle.PushButton; }
        }
        public override Image Image {
            get { return WindowsFormsApplication7.Properties.Resources.menu1; }
        }
        public override string Caption {
            get { return "Menu"; }
        }
        public override bool Visible {
            get { return true; }
        }
    }
}
