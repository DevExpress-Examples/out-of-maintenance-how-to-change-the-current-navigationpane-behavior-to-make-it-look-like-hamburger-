Namespace HamburgerMenu
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.navigationPane1 = New DevExpress.XtraBars.Navigation.NavigationPane()
			Me.navigationPage1 = New DevExpress.XtraBars.Navigation.NavigationPage()
			Me.navigationPage2 = New DevExpress.XtraBars.Navigation.NavigationPage()
			Me.navigationPage3 = New DevExpress.XtraBars.Navigation.NavigationPage()
			Me.navigationPane1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' navigationPane1
			' 
			Me.navigationPane1.Controls.Add(Me.navigationPage1)
			Me.navigationPane1.Controls.Add(Me.navigationPage2)
			Me.navigationPane1.Controls.Add(Me.navigationPage3)
			Me.navigationPane1.Dock = System.Windows.Forms.DockStyle.Left
			Me.navigationPane1.Location = New System.Drawing.Point(0, 0)
			Me.navigationPane1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
			Me.navigationPane1.Name = "navigationPane1"
			Me.navigationPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() { Me.navigationPage1, Me.navigationPage2, Me.navigationPage3})
			Me.navigationPane1.RegularSize = New System.Drawing.Size(400, 430)
			Me.navigationPane1.SelectedPage = Me.navigationPage2
			Me.navigationPane1.SelectedPageIndex = 0
			Me.navigationPane1.Size = New System.Drawing.Size(400, 430)
			Me.navigationPane1.TabIndex = 0
			Me.navigationPane1.Text = "navigationPane1"
			' 
			' navigationPage1
			' 
			Me.navigationPage1.Caption = "navigationPage1"
			Me.navigationPage1.Image = (DirectCast(resources.GetObject("navigationPage1.Image"), System.Drawing.Image))
			Me.navigationPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
			Me.navigationPage1.Name = "navigationPage1"
			Me.navigationPage1.Size = New System.Drawing.Size(326, 360)
			' 
			' navigationPage2
			' 
			Me.navigationPage2.Caption = "navigationPage2"
			Me.navigationPage2.Image = (DirectCast(resources.GetObject("navigationPage2.Image"), System.Drawing.Image))
			Me.navigationPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
			Me.navigationPage2.Name = "navigationPage2"
			Me.navigationPage2.Size = New System.Drawing.Size(326, 360)
			' 
			' navigationPage3
			' 
			Me.navigationPage3.Caption = "navigationPage3"
			Me.navigationPage3.Image = (DirectCast(resources.GetObject("navigationPage3.Image"), System.Drawing.Image))
			Me.navigationPage3.ImageUri.Uri = "New"
			Me.navigationPage3.Name = "navigationPage3"
			Me.navigationPage3.Size = New System.Drawing.Size(326, 360)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(835, 430)
			Me.Controls.Add(Me.navigationPane1)
			Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
			Me.Name = "Form1"
			Me.Text = "HamburgerMenu"
			Me.navigationPane1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private navigationPane1 As DevExpress.XtraBars.Navigation.NavigationPane
		Private navigationPage1 As DevExpress.XtraBars.Navigation.NavigationPage
		Private navigationPage2 As DevExpress.XtraBars.Navigation.NavigationPage
		Private navigationPage3 As DevExpress.XtraBars.Navigation.NavigationPage
	End Class
End Namespace

