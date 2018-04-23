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
			AddHandler buttonPanel.ButtonClick, AddressOf ButtonsPanel_ButtonClick
		End Sub

		Private Sub navigationPane1_StateChanged(ByVal sender As Object, ByVal e As StateChangedEventArgs)
			If e.State = NavigationPaneState.Collapsed Then
				navigationPane1.PageProperties.ShowMode = ItemShowMode.Image
				navigationPane1.LayoutChanged()
				Dim newSize As Size = (TryCast(navigationPane1, INavigationPane)).RegularMinSize
				navigationPane1.Width = newSize.Width - NavigationPane.StickyWidth
			End If
		End Sub
		Private Sub ButtonsPanel_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs)
			If navigationPane1.State = NavigationPaneState.Collapsed Then
				navigationPane1.State = NavigationPaneState.Default
				Return
			End If
			If navigationPane1.PageProperties.ShowMode = ItemShowMode.Image Then
				navigationPane1.PageProperties.ShowMode = ItemShowMode.ImageAndText
			Else
				navigationPane1.PageProperties.ShowMode = ItemShowMode.Image
			End If
		End Sub
	End Class
	Public Class CustomNavigationButton
		Inherits NavigationButton

		Private paneCore As NavigationPane
		Public Sub New(ByVal navigationPane1 As NavigationPane)
			MyBase.New(Nothing)
			paneCore = navigationPane1
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
