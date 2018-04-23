Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraBars.Docking
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors

Namespace HamburgerMenu
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            navigationPane1.PageProperties.ShowMode = ItemShowMode.Image
            AddHandler navigationPane1.StateChanged, AddressOf navigationPane1_StateChanged
            Dim button As New CustomNavigationButton(navigationPane1)
            Dim buttonPanel As ButtonsPanel = TryCast((TryCast(navigationPane1, INavigationPane)).ButtonsPanel, ButtonsPanel)
            buttonPanel.Buttons.Insert(0, button)

            For i As Integer = 0 To buttonPanel.Buttons.Count - 1
                CType(buttonPanel.Buttons(i), NavigationButton).VisibleIndex = i
            Next i

            AddHandler buttonPanel.ButtonClick, AddressOf ButtonsPanel_ButtonClick
        End Sub

        Private Sub navigationPane1_StateChanged(ByVal sender As Object, ByVal e As StateChangedEventArgs)
            Dim navPane As NavigationPane = TryCast(sender, NavigationPane)

            If e.State = NavigationPaneState.Collapsed Then
                navPane.PageProperties.ShowMode = ItemShowMode.Image
                navPane.LayoutChanged()
                Dim newSize As Size = (TryCast(navPane, INavigationPane)).RegularMinSize
                navPane.Width = newSize.Width - NavigationPane.StickyWidth
            End If
        End Sub
        Private Sub ButtonsPanel_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs)
            Dim panel As NavigationPaneButtonsPanel = TryCast(sender, NavigationPaneButtonsPanel)
            Dim navPane As NavigationPane = TryCast(panel.Owner, NavigationPane)

            If navPane.State = NavigationPaneState.Collapsed Then
                navPane.State = NavigationPaneState.Default
                Return
            End If
            If navPane.PageProperties.ShowMode = ItemShowMode.Image Then
                navPane.PageProperties.ShowMode = ItemShowMode.ImageAndText
            Else
                navPane.PageProperties.ShowMode = ItemShowMode.Image
            End If
        End Sub
    End Class
    Public Class CustomNavigationButton
        Inherits NavigationButton

        Private paneCore As NavigationPane
        Public Sub New(ByVal navigationPane As NavigationPane)
            MyBase.New(navigationPane.SelectedPage)
            paneCore = navigationPane
        End Sub
        Public Overrides ReadOnly Property UseCaption() As Boolean
            Get
                Return paneCore.PageProperties.ShowMode = ItemShowMode.ImageAndText OrElse paneCore.PageProperties.ShowMode = ItemShowMode.Text OrElse ((paneCore.PageProperties.ShowMode = ItemShowMode.ImageOrText OrElse paneCore.PageProperties.ShowMode = ItemShowMode.Default) And Image Is Nothing)
            End Get
        End Property
        Public Overrides ReadOnly Property UseImage() As Boolean
            Get
                Return paneCore.PageProperties.ShowMode <> ItemShowMode.Text
            End Get
        End Property
        Public Overrides ReadOnly Property Style() As ButtonStyle
            Get
                Return ButtonStyle.PushButton
            End Get
        End Property
        Public Overrides ReadOnly Property Image() As Image
            Get
                Return My.Resources.menu1
            End Get
        End Property
        Public Overrides ReadOnly Property Caption() As String
            Get
                Return "Menu"
            End Get
        End Property
        Public Overrides ReadOnly Property Visible() As Boolean
            Get
                Return True
            End Get
        End Property
    End Class
End Namespace
