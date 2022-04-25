Imports GRC
Imports System.Data.SqlClient

Public Class FrEntreprise
    Inherits GRC.FrBase

    Private GestCompta As Compta
    Friend WithEvents MDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JournalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PPieceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleLigneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MMtDebDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MMtCreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeverrouillerNumCompteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrenomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FonctionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroTel As System.Windows.Forms.DataGridViewTextBoxColumn
    Private _typeEnt As FrListeClient.TypesEntreprise = FrListeClient.TypesEntreprise.Client

#Region " Constructors "
    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Me.id = -1
        Me.AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal nEntreprise As Integer)
        Me.New()
        Me.id = nEntreprise
        Me.AjouterEnregistrement = False
    End Sub
#End Region

#Region "Props"
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DatagridViewComboboxColumnCustom1 As AgriFact.DatagridViewComboboxColumnCustom
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDisableButtonColumn1 As AgriFact.DataGridViewDisableButtonColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TxDateDebFiltreCompte As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents WatermarkProvider1 As Windark.Windows.Controls.WatermarkProvider
    Friend WithEvents TxDateFinFiltreCompte As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JusquauToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxDateDebFiltreProduits As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TxDateFinFiltreProduits As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TextBoxAdresseFactu As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCPFactu As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxVilleFactu As System.Windows.Forms.TextBox
    Friend WithEvents ButtonRechercherVilleFactu As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents TextBoxSuffixeFactu As System.Windows.Forms.TextBox
    Friend WithEvents PanelCoordFactu As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPaysFactu As System.Windows.Forms.ComboBox
    Friend WithEvents PanelCoordLiv As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxPaysLiv As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSuffixeLiv As System.Windows.Forms.TextBox
    Friend WithEvents GradientNavigationButtonRechercherVilleLiv As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents TextBoxAdresseLiv As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCPLiv As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxVilleLiv As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GradientNavigationButton1 As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents tpCompta As System.Windows.Forms.TabPage
    Friend WithEvents BindingSourceAffichageMouvements As System.Windows.Forms.BindingSource
    Friend WithEvents DsAgrigest As AgriFact.DsAgrigest
    Friend WithEvents DataGridViewAffichageMouvements As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonFiltrerMouvementsCompta As System.Windows.Forms.Button
    Friend WithEvents ComboBoxFiltreDossier As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

    Public Property TypeEntreprise() As FrListeClient.TypesEntreprise
        Get
            Return _typeEnt
        End Get
        Set(ByVal value As FrListeClient.TypesEntreprise)
            _typeEnt = value
        End Set
    End Property

    Public ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.EntrepriseBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.EntrepriseBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property nEntreprise() As String
        Get
            Return Convert.ToString(Me.CurrentDrv("nEntreprise"))
        End Get
    End Property
#End Region

#Region " Code généré par le Concepteur Windows Form "

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents TpTel As System.Windows.Forms.TabPage
    Friend WithEvents TelephoneEntrepriseDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents navTels As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents NEntrepriseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeDataGridViewTextBoxColumn As AgriFact.DatagridViewComboboxColumnCustom
    Friend WithEvents NumeroDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTel As AgriFact.DataGridViewDisableButtonColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpContacts As System.Windows.Forms.TabPage
    Friend WithEvents tpCompte As System.Windows.Forms.TabPage
    Friend WithEvents tpProds As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbListePiece As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TbNewPiece As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents MesVFacturesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MesDevisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MesBonsDeCommandeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MesBonsDeLivraisonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouvelleVFactureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouveauDevisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MesBonsDeRéceptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouveauBonDeCommandeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouveauBonDeLivraisonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouveauBonDeRéceptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MesAFacturesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouvelleAFactureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabAdresses As System.Windows.Forms.TabControl
    Friend WithEvents TpAdresseFactu As System.Windows.Forms.TabPage
    Friend WithEvents TpAdresseL As System.Windows.Forms.TabPage
    Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ds As System.Data.DataSet
    Friend WithEvents TelephoneEntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsEntreprises As AgriFact.DsEntreprises
    Friend WithEvents RecapCompteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecapCompteTA As AgriFact.DsEntreprisesTableAdapters.RecapCompteTA
    Friend WithEvents RecapProduitsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RecapProduitsTA As AgriFact.DsEntreprisesTableAdapters.RecapProduitsTA
    Friend WithEvents RecapCompteDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RecapProduitsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PersonneDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbMesEvents As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents MesÉvènementsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouvelÉvènementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents GradientCaption2 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents GradientCaption3 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbNewContact As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSupprContact As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GestionControles1 As AgriFact.GestionControles
    'Friend WithEvents GestionControles2 As Test.GestionControles
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents BindingSourceDossiers As System.Windows.Forms.BindingSource
    Friend WithEvents DossiersTableAdapter As AgriFact.DsAgrigestTableAdapters.DossiersTableAdapter
    Friend WithEvents LabelSolde As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelSoldeCredit As System.Windows.Forms.Label
    Friend WithEvents LabelSoldeDebit As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFiltreLettrage As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrEntreprise))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpCompte = New System.Windows.Forms.TabPage
        Me.RecapCompteDataGridView = New System.Windows.Forms.DataGridView
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RecapCompteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsEntreprises = New AgriFact.DsEntreprises
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.TxDateDebFiltreCompte = New System.Windows.Forms.ToolStripTextBox
        Me.JusquauToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TxDateFinFiltreCompte = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.tpContacts = New System.Windows.Forms.TabPage
        Me.PersonneDataGridView = New System.Windows.Forms.DataGridView
        Me.ContactsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.TbNewContact = New System.Windows.Forms.ToolStripButton
        Me.TbSupprContact = New System.Windows.Forms.ToolStripButton
        Me.tpProds = New System.Windows.Forms.TabPage
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.TxDateDebFiltreProduits = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.TxDateFinFiltreProduits = New System.Windows.Forms.ToolStripTextBox
        Me.RecapProduitsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RecapProduitsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpCompta = New System.Windows.Forms.TabPage
        Me.ComboBoxFiltreLettrage = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.LabelSoldeCredit = New System.Windows.Forms.Label
        Me.LabelSoldeDebit = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LabelSolde = New System.Windows.Forms.Label
        Me.ButtonFiltrerMouvementsCompta = New System.Windows.Forms.Button
        Me.ComboBoxFiltreDossier = New System.Windows.Forms.ComboBox
        Me.BindingSourceDossiers = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrigest = New AgriFact.DsAgrigest
        Me.Label4 = New System.Windows.Forms.Label
        Me.DataGridViewAffichageMouvements = New System.Windows.Forms.DataGridView
        Me.MDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JournalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PPieceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleLigneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MMtDebDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MMtCreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BindingSourceAffichageMouvements = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbMesEvents = New System.Windows.Forms.ToolStripDropDownButton
        Me.MesÉvènementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NouvelÉvènementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbListePiece = New System.Windows.Forms.ToolStripDropDownButton
        Me.MesVFacturesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MesDevisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MesBonsDeCommandeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MesBonsDeLivraisonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MesAFacturesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MesBonsDeRéceptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbNewPiece = New System.Windows.Forms.ToolStripDropDownButton
        Me.NouvelleVFactureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NouveauDevisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NouveauBonDeCommandeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NouveauBonDeLivraisonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NouvelleAFactureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NouveauBonDeRéceptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.DeverrouillerNumCompteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.TabAdresses = New System.Windows.Forms.TabControl
        Me.TpTel = New System.Windows.Forms.TabPage
        Me.TelephoneEntrepriseDataGridView = New System.Windows.Forms.DataGridView
        Me.NEntrepriseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeDataGridViewTextBoxColumn = New AgriFact.DatagridViewComboboxColumnCustom
        Me.NumeroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColTel = New AgriFact.DataGridViewDisableButtonColumn
        Me.TelephoneEntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds = New System.Data.DataSet
        Me.navTels = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.TpAdresseFactu = New System.Windows.Forms.TabPage
        Me.PanelCoordFactu = New System.Windows.Forms.Panel
        Me.ComboBoxPaysFactu = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxSuffixeFactu = New System.Windows.Forms.TextBox
        Me.ButtonRechercherVilleFactu = New Ascend.Windows.Forms.GradientNavigationButton
        Me.TextBoxAdresseFactu = New System.Windows.Forms.TextBox
        Me.TextBoxCPFactu = New System.Windows.Forms.TextBox
        Me.TextBoxVilleFactu = New System.Windows.Forms.TextBox
        Me.TpAdresseL = New System.Windows.Forms.TabPage
        Me.PanelCoordLiv = New System.Windows.Forms.Panel
        Me.ComboBoxPaysLiv = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxSuffixeLiv = New System.Windows.Forms.TextBox
        Me.GradientNavigationButtonRechercherVilleLiv = New Ascend.Windows.Forms.GradientNavigationButton
        Me.TextBoxAdresseLiv = New System.Windows.Forms.TextBox
        Me.TextBoxCPLiv = New System.Windows.Forms.TextBox
        Me.TextBoxVilleLiv = New System.Windows.Forms.TextBox
        Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GestionControles1 = New AgriFact.GestionControles
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.GradientCaption2 = New Ascend.Windows.Forms.GradientCaption
        Me.GradientCaption3 = New Ascend.Windows.Forms.GradientCaption
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DatagridViewComboboxColumnCustom1 = New AgriFact.DatagridViewComboboxColumnCustom
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewDisableButtonColumn1 = New AgriFact.DataGridViewDisableButtonColumn
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.WatermarkProvider1 = New Windark.Windows.Controls.WatermarkProvider(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GradientNavigationButton1 = New Ascend.Windows.Forms.GradientNavigationButton
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.RecapCompteTA = New AgriFact.DsEntreprisesTableAdapters.RecapCompteTA
        Me.RecapProduitsTA = New AgriFact.DsEntreprisesTableAdapters.RecapProduitsTA
        Me.DossiersTableAdapter = New AgriFact.DsAgrigestTableAdapters.DossiersTableAdapter
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrenomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FonctionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumeroTel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1.SuspendLayout()
        Me.tpCompte.SuspendLayout()
        CType(Me.RecapCompteDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecapCompteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsEntreprises, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.tpContacts.SuspendLayout()
        CType(Me.PersonneDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContactsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.tpProds.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        CType(Me.RecapProduitsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecapProduitsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCompta.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.BindingSourceDossiers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrigest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewAffichageMouvements, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceAffichageMouvements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TabAdresses.SuspendLayout()
        Me.TpTel.SuspendLayout()
        CType(Me.TelephoneEntrepriseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TelephoneEntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.navTels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.navTels.SuspendLayout()
        Me.TpAdresseFactu.SuspendLayout()
        Me.PanelCoordFactu.SuspendLayout()
        Me.TpAdresseL.SuspendLayout()
        Me.PanelCoordLiv.SuspendLayout()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList16
        '
        Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList16.Images.SetKeyName(0, "")
        '
        'ImageList32
        '
        Me.ImageList32.ImageStream = CType(resources.GetObject("ImageList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList32.Images.SetKeyName(0, "")
        Me.ImageList32.Images.SetKeyName(1, "")
        Me.ImageList32.Images.SetKeyName(2, "")
        Me.ImageList32.Images.SetKeyName(3, "")
        Me.ImageList32.Images.SetKeyName(4, "")
        '
        'ImageList24
        '
        Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList24.Images.SetKeyName(0, "")
        Me.ImageList24.Images.SetKeyName(1, "")
        Me.ImageList24.Images.SetKeyName(2, "")
        Me.ImageList24.Images.SetKeyName(3, "")
        Me.ImageList24.Images.SetKeyName(4, "")
        Me.ImageList24.Images.SetKeyName(5, "")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "")
        Me.ImageList1.Images.SetKeyName(13, "")
        Me.ImageList1.Images.SetKeyName(14, "")
        Me.ImageList1.Images.SetKeyName(15, "")
        Me.ImageList1.Images.SetKeyName(16, "")
        Me.ImageList1.Images.SetKeyName(17, "")
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpCompte)
        Me.TabControl1.Controls.Add(Me.tpContacts)
        Me.TabControl1.Controls.Add(Me.tpProds)
        Me.TabControl1.Controls.Add(Me.tpCompta)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(360, 283)
        Me.TabControl1.TabIndex = 20
        '
        'tpCompte
        '
        Me.tpCompte.AutoScroll = True
        Me.tpCompte.Controls.Add(Me.RecapCompteDataGridView)
        Me.tpCompte.Controls.Add(Me.StatusStrip1)
        Me.tpCompte.Location = New System.Drawing.Point(4, 22)
        Me.tpCompte.Name = "tpCompte"
        Me.tpCompte.Size = New System.Drawing.Size(352, 257)
        Me.tpCompte.TabIndex = 1
        Me.tpCompte.Text = "Histo"
        Me.tpCompte.UseVisualStyleBackColor = True
        '
        'RecapCompteDataGridView
        '
        Me.RecapCompteDataGridView.AllowUserToAddRows = False
        Me.RecapCompteDataGridView.AllowUserToDeleteRows = False
        Me.RecapCompteDataGridView.AutoGenerateColumns = False
        Me.RecapCompteDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.LibelleDataGridViewTextBoxColumn, Me.MontantDataGridViewTextBoxColumn})
        Me.RecapCompteDataGridView.DataSource = Me.RecapCompteBindingSource
        Me.RecapCompteDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RecapCompteDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.RecapCompteDataGridView.Name = "RecapCompteDataGridView"
        Me.RecapCompteDataGridView.ReadOnly = True
        Me.RecapCompteDataGridView.Size = New System.Drawing.Size(352, 235)
        Me.RecapCompteDataGridView.TabIndex = 2
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.Width = 55
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MontantDataGridViewTextBoxColumn
        '
        Me.MontantDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MontantDataGridViewTextBoxColumn.DataPropertyName = "montant"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C2"
        Me.MontantDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.MontantDataGridViewTextBoxColumn.HeaderText = "Montant"
        Me.MontantDataGridViewTextBoxColumn.Name = "MontantDataGridViewTextBoxColumn"
        Me.MontantDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantDataGridViewTextBoxColumn.Width = 71
        '
        'RecapCompteBindingSource
        '
        Me.RecapCompteBindingSource.DataMember = "RecapCompte"
        Me.RecapCompteBindingSource.DataSource = Me.DsEntreprises
        '
        'DsEntreprises
        '
        Me.DsEntreprises.DataSetName = "DsEntreprises"
        Me.DsEntreprises.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StatusStrip1
        '
        Me.StatusStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripStatusLabel1, Me.lbTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 235)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(352, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.TxDateDebFiltreCompte, Me.JusquauToolStripMenuItem, Me.TxDateFinFiltreCompte})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripDropDownButton1.Text = "Filtrer le compte client"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Enabled = False
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem1.Text = "depuis le"
        '
        'TxDateDebFiltreCompte
        '
        Me.TxDateDebFiltreCompte.Name = "TxDateDebFiltreCompte"
        Me.TxDateDebFiltreCompte.Size = New System.Drawing.Size(100, 23)
        Me.WatermarkProvider1.SetWatermark(Me.TxDateDebFiltreCompte, "<date>")
        '
        'JusquauToolStripMenuItem
        '
        Me.JusquauToolStripMenuItem.Enabled = False
        Me.JusquauToolStripMenuItem.Name = "JusquauToolStripMenuItem"
        Me.JusquauToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.JusquauToolStripMenuItem.Text = "jusqu'au"
        '
        'TxDateFinFiltreCompte
        '
        Me.TxDateFinFiltreCompte.Name = "TxDateFinFiltreCompte"
        Me.TxDateFinFiltreCompte.Size = New System.Drawing.Size(100, 23)
        Me.WatermarkProvider1.SetWatermark(Me.TxDateFinFiltreCompte, "<date>")
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(264, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Total :"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTotal
        '
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(44, 17)
        Me.lbTotal.Text = "lbTotal"
        '
        'tpContacts
        '
        Me.tpContacts.AutoScroll = True
        Me.tpContacts.Controls.Add(Me.PersonneDataGridView)
        Me.tpContacts.Controls.Add(Me.ToolStrip2)
        Me.tpContacts.Location = New System.Drawing.Point(4, 22)
        Me.tpContacts.Name = "tpContacts"
        Me.tpContacts.Size = New System.Drawing.Size(352, 257)
        Me.tpContacts.TabIndex = 0
        Me.tpContacts.Text = "Contacts"
        Me.tpContacts.UseVisualStyleBackColor = True
        '
        'PersonneDataGridView
        '
        Me.PersonneDataGridView.AllowUserToAddRows = False
        Me.PersonneDataGridView.AllowUserToDeleteRows = False
        Me.PersonneDataGridView.AutoGenerateColumns = False
        Me.PersonneDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomDataGridViewTextBoxColumn, Me.PrenomDataGridViewTextBoxColumn, Me.FonctionDataGridViewTextBoxColumn, Me.EMailDataGridViewTextBoxColumn, Me.NumeroTel})
        Me.PersonneDataGridView.DataSource = Me.ContactsBindingSource
        Me.PersonneDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonneDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.PersonneDataGridView.Name = "PersonneDataGridView"
        Me.PersonneDataGridView.ReadOnly = True
        Me.PersonneDataGridView.RowHeadersWidth = 25
        Me.PersonneDataGridView.Size = New System.Drawing.Size(352, 232)
        Me.PersonneDataGridView.TabIndex = 11
        '
        'ContactsBindingSource
        '
        Me.ContactsBindingSource.DataMember = "Personne"
        Me.ContactsBindingSource.DataSource = Me.DsEntreprises
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbNewContact, Me.TbSupprContact})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(352, 25)
        Me.ToolStrip2.TabIndex = 12
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'TbNewContact
        '
        Me.TbNewContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNewContact.Image = CType(resources.GetObject("TbNewContact.Image"), System.Drawing.Image)
        Me.TbNewContact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNewContact.Name = "TbNewContact"
        Me.TbNewContact.Size = New System.Drawing.Size(23, 22)
        Me.TbNewContact.Text = "Nouveau contact"
        '
        'TbSupprContact
        '
        Me.TbSupprContact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSupprContact.Image = CType(resources.GetObject("TbSupprContact.Image"), System.Drawing.Image)
        Me.TbSupprContact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSupprContact.Name = "TbSupprContact"
        Me.TbSupprContact.Size = New System.Drawing.Size(23, 22)
        Me.TbSupprContact.Text = "Supprimer le contact"
        '
        'tpProds
        '
        Me.tpProds.AutoScroll = True
        Me.tpProds.Controls.Add(Me.StatusStrip2)
        Me.tpProds.Controls.Add(Me.RecapProduitsDataGridView)
        Me.tpProds.Location = New System.Drawing.Point(4, 22)
        Me.tpProds.Name = "tpProds"
        Me.tpProds.Size = New System.Drawing.Size(352, 257)
        Me.tpProds.TabIndex = 2
        Me.tpProds.Text = "Produits"
        Me.tpProds.UseVisualStyleBackColor = True
        '
        'StatusStrip2
        '
        Me.StatusStrip2.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton2})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 235)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(352, 22)
        Me.StatusStrip2.SizingGrip = False
        Me.StatusStrip2.TabIndex = 4
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.TxDateDebFiltreProduits, Me.ToolStripMenuItem3, Me.TxDateFinFiltreProduits})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripDropDownButton2.Text = "Filtrer le compte client"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Enabled = False
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem2.Text = "depuis le"
        '
        'TxDateDebFiltreProduits
        '
        Me.TxDateDebFiltreProduits.Name = "TxDateDebFiltreProduits"
        Me.TxDateDebFiltreProduits.Size = New System.Drawing.Size(100, 23)
        Me.WatermarkProvider1.SetWatermark(Me.TxDateDebFiltreProduits, "<date>")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Enabled = False
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItem3.Text = "jusqu'au"
        '
        'TxDateFinFiltreProduits
        '
        Me.TxDateFinFiltreProduits.Name = "TxDateFinFiltreProduits"
        Me.TxDateFinFiltreProduits.Size = New System.Drawing.Size(100, 23)
        Me.WatermarkProvider1.SetWatermark(Me.TxDateFinFiltreProduits, "<date>")
        '
        'RecapProduitsDataGridView
        '
        Me.RecapProduitsDataGridView.AllowUserToAddRows = False
        Me.RecapProduitsDataGridView.AllowUserToDeleteRows = False
        Me.RecapProduitsDataGridView.AutoGenerateColumns = False
        Me.RecapProduitsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13})
        Me.RecapProduitsDataGridView.DataSource = Me.RecapProduitsBindingSource
        Me.RecapProduitsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RecapProduitsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.RecapProduitsDataGridView.Name = "RecapProduitsDataGridView"
        Me.RecapProduitsDataGridView.ReadOnly = True
        Me.RecapProduitsDataGridView.Size = New System.Drawing.Size(352, 257)
        Me.RecapProduitsDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "famille"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn7.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 64
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "codeproduit"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn10.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 57
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "libelle"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn11.HeaderText = "Produit"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "unite1"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn12.HeaderText = "Qte"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 49
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "libunite1"
        Me.DataGridViewTextBoxColumn13.HeaderText = ""
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 19
        '
        'RecapProduitsBindingSource
        '
        Me.RecapProduitsBindingSource.DataMember = "RecapProduits"
        Me.RecapProduitsBindingSource.DataSource = Me.DsEntreprises
        '
        'tpCompta
        '
        Me.tpCompta.AutoScroll = True
        Me.tpCompta.Controls.Add(Me.ComboBoxFiltreLettrage)
        Me.tpCompta.Controls.Add(Me.TableLayoutPanel1)
        Me.tpCompta.Controls.Add(Me.LabelSolde)
        Me.tpCompta.Controls.Add(Me.ButtonFiltrerMouvementsCompta)
        Me.tpCompta.Controls.Add(Me.ComboBoxFiltreDossier)
        Me.tpCompta.Controls.Add(Me.Label4)
        Me.tpCompta.Controls.Add(Me.DataGridViewAffichageMouvements)
        Me.tpCompta.Location = New System.Drawing.Point(4, 22)
        Me.tpCompta.Name = "tpCompta"
        Me.tpCompta.Size = New System.Drawing.Size(352, 257)
        Me.tpCompta.TabIndex = 4
        Me.tpCompta.Text = "Compta"
        Me.tpCompta.UseVisualStyleBackColor = True
        '
        'ComboBoxFiltreLettrage
        '
        Me.ComboBoxFiltreLettrage.FormattingEnabled = True
        Me.ComboBoxFiltreLettrage.Items.AddRange(New Object() {"Toutes", "Non lettrées", "Lettrées"})
        Me.ComboBoxFiltreLettrage.Location = New System.Drawing.Point(192, 8)
        Me.ComboBoxFiltreLettrage.Name = "ComboBoxFiltreLettrage"
        Me.ComboBoxFiltreLettrage.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxFiltreLettrage.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelSoldeCredit, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelSoldeDebit, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(57, 215)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 39)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'LabelSoldeCredit
        '
        Me.LabelSoldeCredit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LabelSoldeCredit.AutoSize = True
        Me.LabelSoldeCredit.Location = New System.Drawing.Point(114, 25)
        Me.LabelSoldeCredit.Name = "LabelSoldeCredit"
        Me.LabelSoldeCredit.Size = New System.Drawing.Size(70, 13)
        Me.LabelSoldeCredit.TabIndex = 8
        Me.LabelSoldeCredit.Text = "999 999,99 €"
        Me.LabelSoldeCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelSoldeDebit
        '
        Me.LabelSoldeDebit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.LabelSoldeDebit.AutoSize = True
        Me.LabelSoldeDebit.Location = New System.Drawing.Point(15, 25)
        Me.LabelSoldeDebit.Name = "LabelSoldeDebit"
        Me.LabelSoldeDebit.Size = New System.Drawing.Size(70, 13)
        Me.LabelSoldeDebit.TabIndex = 7
        Me.LabelSoldeDebit.Text = "999 999,99 €"
        Me.LabelSoldeDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(132, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Crédit"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Débit"
        '
        'LabelSolde
        '
        Me.LabelSolde.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelSolde.AutoSize = True
        Me.LabelSolde.Location = New System.Drawing.Point(11, 240)
        Me.LabelSolde.Name = "LabelSolde"
        Me.LabelSolde.Size = New System.Drawing.Size(40, 13)
        Me.LabelSolde.TabIndex = 6
        Me.LabelSolde.Text = "Solde :"
        Me.LabelSolde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonFiltrerMouvementsCompta
        '
        Me.ButtonFiltrerMouvementsCompta.Image = CType(resources.GetObject("ButtonFiltrerMouvementsCompta.Image"), System.Drawing.Image)
        Me.ButtonFiltrerMouvementsCompta.Location = New System.Drawing.Point(319, 6)
        Me.ButtonFiltrerMouvementsCompta.Name = "ButtonFiltrerMouvementsCompta"
        Me.ButtonFiltrerMouvementsCompta.Size = New System.Drawing.Size(30, 23)
        Me.ButtonFiltrerMouvementsCompta.TabIndex = 4
        Me.ButtonFiltrerMouvementsCompta.UseVisualStyleBackColor = True
        '
        'ComboBoxFiltreDossier
        '
        Me.ComboBoxFiltreDossier.DataSource = Me.BindingSourceDossiers
        Me.ComboBoxFiltreDossier.DisplayMember = "DDossier"
        Me.ComboBoxFiltreDossier.FormattingEnabled = True
        Me.ComboBoxFiltreDossier.Location = New System.Drawing.Point(57, 8)
        Me.ComboBoxFiltreDossier.Name = "ComboBoxFiltreDossier"
        Me.ComboBoxFiltreDossier.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxFiltreDossier.TabIndex = 3
        Me.ComboBoxFiltreDossier.ValueMember = "DDossier"
        '
        'BindingSourceDossiers
        '
        Me.BindingSourceDossiers.DataMember = "Dossiers"
        Me.BindingSourceDossiers.DataSource = Me.DsAgrigest
        '
        'DsAgrigest
        '
        Me.DsAgrigest.DataSetName = "DsAgrigest"
        Me.DsAgrigest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Dossier :"
        '
        'DataGridViewAffichageMouvements
        '
        Me.DataGridViewAffichageMouvements.AllowUserToAddRows = False
        Me.DataGridViewAffichageMouvements.AllowUserToDeleteRows = False
        Me.DataGridViewAffichageMouvements.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewAffichageMouvements.AutoGenerateColumns = False
        Me.DataGridViewAffichageMouvements.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewAffichageMouvements.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MDateDataGridViewTextBoxColumn, Me.JournalDataGridViewTextBoxColumn, Me.PPieceDataGridViewTextBoxColumn, Me.LibelleLigneDataGridViewTextBoxColumn, Me.MMtDebDataGridViewTextBoxColumn, Me.MMtCreDataGridViewTextBoxColumn})
        Me.DataGridViewAffichageMouvements.DataSource = Me.BindingSourceAffichageMouvements
        Me.DataGridViewAffichageMouvements.Location = New System.Drawing.Point(0, 35)
        Me.DataGridViewAffichageMouvements.Name = "DataGridViewAffichageMouvements"
        Me.DataGridViewAffichageMouvements.ReadOnly = True
        Me.DataGridViewAffichageMouvements.Size = New System.Drawing.Size(352, 174)
        Me.DataGridViewAffichageMouvements.TabIndex = 0
        '
        'MDateDataGridViewTextBoxColumn
        '
        Me.MDateDataGridViewTextBoxColumn.DataPropertyName = "MDate"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.MDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.MDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.MDateDataGridViewTextBoxColumn.Name = "MDateDataGridViewTextBoxColumn"
        Me.MDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.MDateDataGridViewTextBoxColumn.Width = 70
        '
        'JournalDataGridViewTextBoxColumn
        '
        Me.JournalDataGridViewTextBoxColumn.DataPropertyName = "Journal"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.JournalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.JournalDataGridViewTextBoxColumn.HeaderText = "Jal"
        Me.JournalDataGridViewTextBoxColumn.Name = "JournalDataGridViewTextBoxColumn"
        Me.JournalDataGridViewTextBoxColumn.ReadOnly = True
        Me.JournalDataGridViewTextBoxColumn.Width = 30
        '
        'PPieceDataGridViewTextBoxColumn
        '
        Me.PPieceDataGridViewTextBoxColumn.DataPropertyName = "PPiece"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PPieceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.PPieceDataGridViewTextBoxColumn.HeaderText = "Piece"
        Me.PPieceDataGridViewTextBoxColumn.Name = "PPieceDataGridViewTextBoxColumn"
        Me.PPieceDataGridViewTextBoxColumn.ReadOnly = True
        Me.PPieceDataGridViewTextBoxColumn.Width = 55
        '
        'LibelleLigneDataGridViewTextBoxColumn
        '
        Me.LibelleLigneDataGridViewTextBoxColumn.DataPropertyName = "LibelleLigne"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LibelleLigneDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.LibelleLigneDataGridViewTextBoxColumn.HeaderText = "Libellé ligne"
        Me.LibelleLigneDataGridViewTextBoxColumn.Name = "LibelleLigneDataGridViewTextBoxColumn"
        Me.LibelleLigneDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MMtDebDataGridViewTextBoxColumn
        '
        Me.MMtDebDataGridViewTextBoxColumn.DataPropertyName = "MMtDeb"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.MMtDebDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.MMtDebDataGridViewTextBoxColumn.HeaderText = "Débit"
        Me.MMtDebDataGridViewTextBoxColumn.Name = "MMtDebDataGridViewTextBoxColumn"
        Me.MMtDebDataGridViewTextBoxColumn.ReadOnly = True
        Me.MMtDebDataGridViewTextBoxColumn.Width = 80
        '
        'MMtCreDataGridViewTextBoxColumn
        '
        Me.MMtCreDataGridViewTextBoxColumn.DataPropertyName = "MMtCre"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.MMtCreDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.MMtCreDataGridViewTextBoxColumn.HeaderText = "Crédit"
        Me.MMtCreDataGridViewTextBoxColumn.Name = "MMtCreDataGridViewTextBoxColumn"
        Me.MMtCreDataGridViewTextBoxColumn.ReadOnly = True
        Me.MMtCreDataGridViewTextBoxColumn.Width = 80
        '
        'BindingSourceAffichageMouvements
        '
        Me.BindingSourceAffichageMouvements.DataMember = "AffichageMouvements"
        Me.BindingSourceAffichageMouvements.DataSource = Me.DsAgrigest
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.TbDelete, Me.ToolStripSeparator1, Me.TbMesEvents, Me.TbListePiece, Me.TbNewPiece, Me.TbClose, Me.ToolStripSeparator2, Me.DeverrouillerNumCompteToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(871, 34)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = CType(resources.GetObject("TbSave.Image"), System.Drawing.Image)
        Me.TbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(28, 31)
        Me.TbSave.Text = "Enregistrer"
        '
        'TbDelete
        '
        Me.TbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbDelete.Image = CType(resources.GetObject("TbDelete.Image"), System.Drawing.Image)
        Me.TbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDelete.Name = "TbDelete"
        Me.TbDelete.Size = New System.Drawing.Size(27, 31)
        Me.TbDelete.Text = "Supprimer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 34)
        '
        'TbMesEvents
        '
        Me.TbMesEvents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbMesEvents.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MesÉvènementsToolStripMenuItem, Me.NouvelÉvènementToolStripMenuItem})
        Me.TbMesEvents.Image = CType(resources.GetObject("TbMesEvents.Image"), System.Drawing.Image)
        Me.TbMesEvents.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbMesEvents.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbMesEvents.Name = "TbMesEvents"
        Me.TbMesEvents.Size = New System.Drawing.Size(40, 31)
        Me.TbMesEvents.Text = "Mes évènements"
        Me.TbMesEvents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MesÉvènementsToolStripMenuItem
        '
        Me.MesÉvènementsToolStripMenuItem.Name = "MesÉvènementsToolStripMenuItem"
        Me.MesÉvènementsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.MesÉvènementsToolStripMenuItem.Text = "Mes évènements..."
        '
        'NouvelÉvènementToolStripMenuItem
        '
        Me.NouvelÉvènementToolStripMenuItem.Name = "NouvelÉvènementToolStripMenuItem"
        Me.NouvelÉvènementToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.NouvelÉvènementToolStripMenuItem.Text = "Nouvel évènement..."
        '
        'TbListePiece
        '
        Me.TbListePiece.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbListePiece.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MesVFacturesToolStripMenuItem, Me.MesDevisToolStripMenuItem, Me.MesBonsDeCommandeToolStripMenuItem, Me.MesBonsDeLivraisonToolStripMenuItem, Me.MesAFacturesToolStripMenuItem, Me.MesBonsDeRéceptionToolStripMenuItem})
        Me.TbListePiece.Image = CType(resources.GetObject("TbListePiece.Image"), System.Drawing.Image)
        Me.TbListePiece.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbListePiece.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbListePiece.Name = "TbListePiece"
        Me.TbListePiece.Size = New System.Drawing.Size(40, 31)
        Me.TbListePiece.Text = "Liste des pièces"
        '
        'MesVFacturesToolStripMenuItem
        '
        Me.MesVFacturesToolStripMenuItem.Name = "MesVFacturesToolStripMenuItem"
        Me.MesVFacturesToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.MesVFacturesToolStripMenuItem.Tag = "VFacture"
        Me.MesVFacturesToolStripMenuItem.Text = "Mes Factures..."
        '
        'MesDevisToolStripMenuItem
        '
        Me.MesDevisToolStripMenuItem.Name = "MesDevisToolStripMenuItem"
        Me.MesDevisToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.MesDevisToolStripMenuItem.Tag = "VDevis"
        Me.MesDevisToolStripMenuItem.Text = "Mes Devis..."
        '
        'MesBonsDeCommandeToolStripMenuItem
        '
        Me.MesBonsDeCommandeToolStripMenuItem.Name = "MesBonsDeCommandeToolStripMenuItem"
        Me.MesBonsDeCommandeToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.MesBonsDeCommandeToolStripMenuItem.Tag = "VBonCommande"
        Me.MesBonsDeCommandeToolStripMenuItem.Text = "Mes Bons de Commande..."
        '
        'MesBonsDeLivraisonToolStripMenuItem
        '
        Me.MesBonsDeLivraisonToolStripMenuItem.Name = "MesBonsDeLivraisonToolStripMenuItem"
        Me.MesBonsDeLivraisonToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.MesBonsDeLivraisonToolStripMenuItem.Tag = "VBonLivraison"
        Me.MesBonsDeLivraisonToolStripMenuItem.Text = "Mes Bons de Livraison..."
        '
        'MesAFacturesToolStripMenuItem
        '
        Me.MesAFacturesToolStripMenuItem.Name = "MesAFacturesToolStripMenuItem"
        Me.MesAFacturesToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.MesAFacturesToolStripMenuItem.Tag = "AFacture"
        Me.MesAFacturesToolStripMenuItem.Text = "Mes Factures..."
        '
        'MesBonsDeRéceptionToolStripMenuItem
        '
        Me.MesBonsDeRéceptionToolStripMenuItem.Name = "MesBonsDeRéceptionToolStripMenuItem"
        Me.MesBonsDeRéceptionToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.MesBonsDeRéceptionToolStripMenuItem.Tag = "ABonReception"
        Me.MesBonsDeRéceptionToolStripMenuItem.Text = "Mes Bons de Réception..."
        '
        'TbNewPiece
        '
        Me.TbNewPiece.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbNewPiece.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouvelleVFactureToolStripMenuItem, Me.NouveauDevisToolStripMenuItem, Me.NouveauBonDeCommandeToolStripMenuItem, Me.NouveauBonDeLivraisonToolStripMenuItem, Me.NouvelleAFactureToolStripMenuItem, Me.NouveauBonDeRéceptionToolStripMenuItem})
        Me.TbNewPiece.Image = CType(resources.GetObject("TbNewPiece.Image"), System.Drawing.Image)
        Me.TbNewPiece.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbNewPiece.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbNewPiece.Name = "TbNewPiece"
        Me.TbNewPiece.Size = New System.Drawing.Size(40, 31)
        Me.TbNewPiece.Text = "Nouvelle pièce"
        '
        'NouvelleVFactureToolStripMenuItem
        '
        Me.NouvelleVFactureToolStripMenuItem.Name = "NouvelleVFactureToolStripMenuItem"
        Me.NouvelleVFactureToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.NouvelleVFactureToolStripMenuItem.Tag = "VFacture"
        Me.NouvelleVFactureToolStripMenuItem.Text = "Nouvelle Facture..."
        '
        'NouveauDevisToolStripMenuItem
        '
        Me.NouveauDevisToolStripMenuItem.Name = "NouveauDevisToolStripMenuItem"
        Me.NouveauDevisToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.NouveauDevisToolStripMenuItem.Tag = "VDevis"
        Me.NouveauDevisToolStripMenuItem.Text = "Nouveau Devis..."
        '
        'NouveauBonDeCommandeToolStripMenuItem
        '
        Me.NouveauBonDeCommandeToolStripMenuItem.Name = "NouveauBonDeCommandeToolStripMenuItem"
        Me.NouveauBonDeCommandeToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.NouveauBonDeCommandeToolStripMenuItem.Tag = "VBonCommande"
        Me.NouveauBonDeCommandeToolStripMenuItem.Text = "Nouveau Bon de Commande..."
        '
        'NouveauBonDeLivraisonToolStripMenuItem
        '
        Me.NouveauBonDeLivraisonToolStripMenuItem.Name = "NouveauBonDeLivraisonToolStripMenuItem"
        Me.NouveauBonDeLivraisonToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.NouveauBonDeLivraisonToolStripMenuItem.Tag = "VBonLivraison"
        Me.NouveauBonDeLivraisonToolStripMenuItem.Text = "Nouveau Bon de Livraison..."
        '
        'NouvelleAFactureToolStripMenuItem
        '
        Me.NouvelleAFactureToolStripMenuItem.Name = "NouvelleAFactureToolStripMenuItem"
        Me.NouvelleAFactureToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.NouvelleAFactureToolStripMenuItem.Tag = "AFacture"
        Me.NouvelleAFactureToolStripMenuItem.Text = "Nouvelle Facture..."
        '
        'NouveauBonDeRéceptionToolStripMenuItem
        '
        Me.NouveauBonDeRéceptionToolStripMenuItem.Name = "NouveauBonDeRéceptionToolStripMenuItem"
        Me.NouveauBonDeRéceptionToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.NouveauBonDeRéceptionToolStripMenuItem.Tag = "ABonReception"
        Me.NouveauBonDeRéceptionToolStripMenuItem.Text = "Nouveau Bon de Réception..."
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = CType(resources.GetObject("TbClose.Image"), System.Drawing.Image)
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 31)
        Me.TbClose.Text = "Fermer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'DeverrouillerNumCompteToolStripButton
        '
        Me.DeverrouillerNumCompteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeverrouillerNumCompteToolStripButton.Image = Global.AgriFact.My.Resources.Resources.GetPermission
        Me.DeverrouillerNumCompteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeverrouillerNumCompteToolStripButton.Name = "DeverrouillerNumCompteToolStripButton"
        Me.DeverrouillerNumCompteToolStripButton.Size = New System.Drawing.Size(28, 31)
        Me.DeverrouillerNumCompteToolStripButton.Text = "Déverrouiller le numéro de compte"
        '
        'TabAdresses
        '
        Me.TabAdresses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabAdresses.Controls.Add(Me.TpTel)
        Me.TabAdresses.Controls.Add(Me.TpAdresseFactu)
        Me.TabAdresses.Controls.Add(Me.TpAdresseL)
        Me.TabAdresses.Location = New System.Drawing.Point(0, 30)
        Me.TabAdresses.Name = "TabAdresses"
        Me.TabAdresses.SelectedIndex = 0
        Me.TabAdresses.Size = New System.Drawing.Size(360, 251)
        Me.TabAdresses.TabIndex = 22
        '
        'TpTel
        '
        Me.TpTel.Controls.Add(Me.TelephoneEntrepriseDataGridView)
        Me.TpTel.Controls.Add(Me.navTels)
        Me.TpTel.Location = New System.Drawing.Point(4, 22)
        Me.TpTel.Name = "TpTel"
        Me.TpTel.Padding = New System.Windows.Forms.Padding(3)
        Me.TpTel.Size = New System.Drawing.Size(352, 225)
        Me.TpTel.TabIndex = 2
        Me.TpTel.Text = "Téléphones"
        Me.TpTel.UseVisualStyleBackColor = True
        '
        'TelephoneEntrepriseDataGridView
        '
        Me.TelephoneEntrepriseDataGridView.AutoGenerateColumns = False
        Me.TelephoneEntrepriseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TelephoneEntrepriseDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NEntrepriseDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn, Me.NumeroDataGridViewTextBoxColumn, Me.ColTel})
        Me.TelephoneEntrepriseDataGridView.DataSource = Me.TelephoneEntrepriseBindingSource
        Me.TelephoneEntrepriseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TelephoneEntrepriseDataGridView.Location = New System.Drawing.Point(27, 3)
        Me.TelephoneEntrepriseDataGridView.Name = "TelephoneEntrepriseDataGridView"
        Me.TelephoneEntrepriseDataGridView.RowHeadersWidth = 25
        Me.TelephoneEntrepriseDataGridView.Size = New System.Drawing.Size(322, 219)
        Me.TelephoneEntrepriseDataGridView.TabIndex = 1
        '
        'NEntrepriseDataGridViewTextBoxColumn
        '
        Me.NEntrepriseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NEntrepriseDataGridViewTextBoxColumn.DataPropertyName = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.HeaderText = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.Name = "NEntrepriseDataGridViewTextBoxColumn"
        Me.NEntrepriseDataGridViewTextBoxColumn.Width = 68
        '
        'TypeDataGridViewTextBoxColumn
        '
        Me.TypeDataGridViewTextBoxColumn.DataPropertyName = "Type"
        Me.TypeDataGridViewTextBoxColumn.DisplayStyleForCurrentCellOnly = True
        Me.TypeDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.TypeDataGridViewTextBoxColumn.Items.AddRange(New Object() {"Siège", "Portable", "Fax"})
        Me.TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn"
        Me.TypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'NumeroDataGridViewTextBoxColumn
        '
        Me.NumeroDataGridViewTextBoxColumn.DataPropertyName = "Numero"
        Me.NumeroDataGridViewTextBoxColumn.HeaderText = "Numero"
        Me.NumeroDataGridViewTextBoxColumn.Name = "NumeroDataGridViewTextBoxColumn"
        '
        'ColTel
        '
        Me.ColTel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColTel.HeaderText = ""
        Me.ColTel.Image = CType(resources.GetObject("ColTel.Image"), System.Drawing.Image)
        Me.ColTel.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ColTel.Name = "ColTel"
        Me.ColTel.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColTel.ToolTipText = "Appeller"
        Me.ColTel.Width = 30
        '
        'TelephoneEntrepriseBindingSource
        '
        Me.TelephoneEntrepriseBindingSource.DataSource = Me.ds
        Me.TelephoneEntrepriseBindingSource.Position = 0
        '
        'ds
        '
        Me.ds.DataSetName = "NewDataSet"
        '
        'navTels
        '
        Me.navTels.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.navTels.BindingSource = Me.TelephoneEntrepriseBindingSource
        Me.navTels.CountItem = Nothing
        Me.navTels.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.navTels.Dock = System.Windows.Forms.DockStyle.Left
        Me.navTels.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.navTels.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
        Me.navTels.Location = New System.Drawing.Point(3, 3)
        Me.navTels.MoveFirstItem = Nothing
        Me.navTels.MoveLastItem = Nothing
        Me.navTels.MoveNextItem = Nothing
        Me.navTels.MovePreviousItem = Nothing
        Me.navTels.Name = "navTels"
        Me.navTels.PositionItem = Nothing
        Me.navTels.Size = New System.Drawing.Size(24, 219)
        Me.navTels.TabIndex = 0
        Me.navTels.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(21, 20)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(21, 20)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'TpAdresseFactu
        '
        Me.TpAdresseFactu.Controls.Add(Me.PanelCoordFactu)
        Me.TpAdresseFactu.Location = New System.Drawing.Point(4, 22)
        Me.TpAdresseFactu.Name = "TpAdresseFactu"
        Me.TpAdresseFactu.Padding = New System.Windows.Forms.Padding(3)
        Me.TpAdresseFactu.Size = New System.Drawing.Size(352, 225)
        Me.TpAdresseFactu.TabIndex = 0
        Me.TpAdresseFactu.Text = "Facturation"
        Me.TpAdresseFactu.UseVisualStyleBackColor = True
        '
        'PanelCoordFactu
        '
        Me.PanelCoordFactu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelCoordFactu.Controls.Add(Me.ComboBoxPaysFactu)
        Me.PanelCoordFactu.Controls.Add(Me.Label1)
        Me.PanelCoordFactu.Controls.Add(Me.TextBoxSuffixeFactu)
        Me.PanelCoordFactu.Controls.Add(Me.ButtonRechercherVilleFactu)
        Me.PanelCoordFactu.Controls.Add(Me.TextBoxAdresseFactu)
        Me.PanelCoordFactu.Controls.Add(Me.TextBoxCPFactu)
        Me.PanelCoordFactu.Controls.Add(Me.TextBoxVilleFactu)
        Me.PanelCoordFactu.Location = New System.Drawing.Point(6, 6)
        Me.PanelCoordFactu.Name = "PanelCoordFactu"
        Me.PanelCoordFactu.Size = New System.Drawing.Size(340, 213)
        Me.PanelCoordFactu.TabIndex = 24
        '
        'ComboBoxPaysFactu
        '
        Me.ComboBoxPaysFactu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxPaysFactu.FormattingEnabled = True
        Me.ComboBoxPaysFactu.Location = New System.Drawing.Point(50, 177)
        Me.ComboBoxPaysFactu.Name = "ComboBoxPaysFactu"
        Me.ComboBoxPaysFactu.Size = New System.Drawing.Size(287, 21)
        Me.ComboBoxPaysFactu.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Pays :"
        '
        'TextBoxSuffixeFactu
        '
        Me.TextBoxSuffixeFactu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSuffixeFactu.Location = New System.Drawing.Point(279, 150)
        Me.TextBoxSuffixeFactu.Name = "TextBoxSuffixeFactu"
        Me.TextBoxSuffixeFactu.Size = New System.Drawing.Size(58, 20)
        Me.TextBoxSuffixeFactu.TabIndex = 5
        '
        'ButtonRechercherVilleFactu
        '
        Me.ButtonRechercherVilleFactu.ActiveGradientHighColor = System.Drawing.Color.White
        Me.ButtonRechercherVilleFactu.ActiveGradientLowColor = System.Drawing.Color.Moccasin
        Me.ButtonRechercherVilleFactu.ActiveOnClick = False
        Me.ButtonRechercherVilleFactu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRechercherVilleFactu.AntiAlias = True
        Me.ButtonRechercherVilleFactu.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.ButtonRechercherVilleFactu.CornerRadius = New Ascend.CornerRadius(3)
        Me.ButtonRechercherVilleFactu.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.ButtonRechercherVilleFactu.HighColorLuminance = 1.3!
        Me.ButtonRechercherVilleFactu.Image = CType(resources.GetObject("ButtonRechercherVilleFactu.Image"), System.Drawing.Image)
        Me.ButtonRechercherVilleFactu.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonRechercherVilleFactu.Location = New System.Drawing.Point(252, 150)
        Me.ButtonRechercherVilleFactu.LowColorLuminance = 1.3!
        Me.ButtonRechercherVilleFactu.Name = "ButtonRechercherVilleFactu"
        Me.ButtonRechercherVilleFactu.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.ButtonRechercherVilleFactu.Size = New System.Drawing.Size(22, 20)
        Me.ButtonRechercherVilleFactu.StayActiveAfterClick = False
        Me.ButtonRechercherVilleFactu.TabIndex = 4
        Me.ButtonRechercherVilleFactu.TabStop = True
        '
        'TextBoxAdresseFactu
        '
        Me.TextBoxAdresseFactu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxAdresseFactu.Location = New System.Drawing.Point(3, 3)
        Me.TextBoxAdresseFactu.Multiline = True
        Me.TextBoxAdresseFactu.Name = "TextBoxAdresseFactu"
        Me.TextBoxAdresseFactu.Size = New System.Drawing.Size(334, 141)
        Me.TextBoxAdresseFactu.TabIndex = 0
        '
        'TextBoxCPFactu
        '
        Me.TextBoxCPFactu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCPFactu.Location = New System.Drawing.Point(3, 150)
        Me.TextBoxCPFactu.Name = "TextBoxCPFactu"
        Me.TextBoxCPFactu.Size = New System.Drawing.Size(62, 20)
        Me.TextBoxCPFactu.TabIndex = 1
        '
        'TextBoxVilleFactu
        '
        Me.TextBoxVilleFactu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxVilleFactu.Location = New System.Drawing.Point(71, 150)
        Me.TextBoxVilleFactu.Name = "TextBoxVilleFactu"
        Me.TextBoxVilleFactu.Size = New System.Drawing.Size(175, 20)
        Me.TextBoxVilleFactu.TabIndex = 2
        '
        'TpAdresseL
        '
        Me.TpAdresseL.Controls.Add(Me.PanelCoordLiv)
        Me.TpAdresseL.Location = New System.Drawing.Point(4, 22)
        Me.TpAdresseL.Name = "TpAdresseL"
        Me.TpAdresseL.Padding = New System.Windows.Forms.Padding(3)
        Me.TpAdresseL.Size = New System.Drawing.Size(352, 225)
        Me.TpAdresseL.TabIndex = 1
        Me.TpAdresseL.Text = "Livraison"
        Me.TpAdresseL.UseVisualStyleBackColor = True
        '
        'PanelCoordLiv
        '
        Me.PanelCoordLiv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelCoordLiv.Controls.Add(Me.ComboBoxPaysLiv)
        Me.PanelCoordLiv.Controls.Add(Me.Label3)
        Me.PanelCoordLiv.Controls.Add(Me.TextBoxSuffixeLiv)
        Me.PanelCoordLiv.Controls.Add(Me.GradientNavigationButtonRechercherVilleLiv)
        Me.PanelCoordLiv.Controls.Add(Me.TextBoxAdresseLiv)
        Me.PanelCoordLiv.Controls.Add(Me.TextBoxCPLiv)
        Me.PanelCoordLiv.Controls.Add(Me.TextBoxVilleLiv)
        Me.PanelCoordLiv.Location = New System.Drawing.Point(6, 6)
        Me.PanelCoordLiv.Name = "PanelCoordLiv"
        Me.PanelCoordLiv.Size = New System.Drawing.Size(340, 213)
        Me.PanelCoordLiv.TabIndex = 25
        '
        'ComboBoxPaysLiv
        '
        Me.ComboBoxPaysLiv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxPaysLiv.FormattingEnabled = True
        Me.ComboBoxPaysLiv.Location = New System.Drawing.Point(50, 177)
        Me.ComboBoxPaysLiv.Name = "ComboBoxPaysLiv"
        Me.ComboBoxPaysLiv.Size = New System.Drawing.Size(287, 21)
        Me.ComboBoxPaysLiv.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Pays :"
        '
        'TextBoxSuffixeLiv
        '
        Me.TextBoxSuffixeLiv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSuffixeLiv.Location = New System.Drawing.Point(279, 150)
        Me.TextBoxSuffixeLiv.Name = "TextBoxSuffixeLiv"
        Me.TextBoxSuffixeLiv.Size = New System.Drawing.Size(58, 20)
        Me.TextBoxSuffixeLiv.TabIndex = 5
        '
        'GradientNavigationButtonRechercherVilleLiv
        '
        Me.GradientNavigationButtonRechercherVilleLiv.ActiveGradientHighColor = System.Drawing.Color.White
        Me.GradientNavigationButtonRechercherVilleLiv.ActiveGradientLowColor = System.Drawing.Color.Moccasin
        Me.GradientNavigationButtonRechercherVilleLiv.ActiveOnClick = False
        Me.GradientNavigationButtonRechercherVilleLiv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientNavigationButtonRechercherVilleLiv.AntiAlias = True
        Me.GradientNavigationButtonRechercherVilleLiv.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.GradientNavigationButtonRechercherVilleLiv.CornerRadius = New Ascend.CornerRadius(3)
        Me.GradientNavigationButtonRechercherVilleLiv.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.GradientNavigationButtonRechercherVilleLiv.HighColorLuminance = 1.3!
        Me.GradientNavigationButtonRechercherVilleLiv.Image = CType(resources.GetObject("GradientNavigationButtonRechercherVilleLiv.Image"), System.Drawing.Image)
        Me.GradientNavigationButtonRechercherVilleLiv.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GradientNavigationButtonRechercherVilleLiv.Location = New System.Drawing.Point(252, 150)
        Me.GradientNavigationButtonRechercherVilleLiv.LowColorLuminance = 1.3!
        Me.GradientNavigationButtonRechercherVilleLiv.Name = "GradientNavigationButtonRechercherVilleLiv"
        Me.GradientNavigationButtonRechercherVilleLiv.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientNavigationButtonRechercherVilleLiv.Size = New System.Drawing.Size(22, 20)
        Me.GradientNavigationButtonRechercherVilleLiv.StayActiveAfterClick = False
        Me.GradientNavigationButtonRechercherVilleLiv.TabIndex = 4
        Me.GradientNavigationButtonRechercherVilleLiv.TabStop = True
        '
        'TextBoxAdresseLiv
        '
        Me.TextBoxAdresseLiv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxAdresseLiv.Location = New System.Drawing.Point(3, 3)
        Me.TextBoxAdresseLiv.Multiline = True
        Me.TextBoxAdresseLiv.Name = "TextBoxAdresseLiv"
        Me.TextBoxAdresseLiv.Size = New System.Drawing.Size(334, 141)
        Me.TextBoxAdresseLiv.TabIndex = 0
        '
        'TextBoxCPLiv
        '
        Me.TextBoxCPLiv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCPLiv.Location = New System.Drawing.Point(3, 150)
        Me.TextBoxCPLiv.Name = "TextBoxCPLiv"
        Me.TextBoxCPLiv.Size = New System.Drawing.Size(62, 20)
        Me.TextBoxCPLiv.TabIndex = 1
        '
        'TextBoxVilleLiv
        '
        Me.TextBoxVilleLiv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxVilleLiv.Location = New System.Drawing.Point(71, 150)
        Me.TextBoxVilleLiv.Name = "TextBoxVilleLiv"
        Me.TextBoxVilleLiv.Size = New System.Drawing.Size(175, 20)
        Me.TextBoxVilleLiv.TabIndex = 2
        '
        'EntrepriseBindingSource
        '
        Me.EntrepriseBindingSource.DataSource = Me.ds
        Me.EntrepriseBindingSource.Position = 0
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(1)
        Me.GradientPanel2.Controls.Add(Me.GestionControles1)
        Me.GradientPanel2.Controls.Add(Me.GradientCaption1)
        Me.GradientPanel2.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(465, 463)
        Me.GradientPanel2.TabIndex = 23
        '
        'GestionControles1
        '
        Me.GestionControles1.AutorisationListe = Nothing
        Me.GestionControles1.Autorisations = ""
        Me.GestionControles1.AutoriseAjt = True
        Me.GestionControles1.AutoriseModif = True
        Me.GestionControles1.AutoriseSuppr = True
        Me.GestionControles1.AutoSize = True
        Me.GestionControles1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GestionControles1.DataSource = Nothing
        Me.GestionControles1.DsBase = Nothing
        Me.GestionControles1.FiltreAffichage = ""
        Me.GestionControles1.Label1Top = 10
        Me.GestionControles1.LabelLeft = 10
        Me.GestionControles1.LargeurText = 280
        Me.GestionControles1.LiaisonDonnees = True
        Me.GestionControles1.Lien = Nothing
        Me.GestionControles1.LigneHauteur = 20
        Me.GestionControles1.LigneIntervale = 5
        Me.GestionControles1.Location = New System.Drawing.Point(0, 24)
        Me.GestionControles1.MinimumSize = New System.Drawing.Size(30, 30)
        Me.GestionControles1.Name = "GestionControles1"
        Me.GestionControles1.NomTableConfig = Nothing
        Me.GestionControles1.NuméroNiveau1 = 0
        Me.GestionControles1.Size = New System.Drawing.Size(485, 439)
        Me.GestionControles1.TabIndex = 0
        Me.GestionControles1.Table = "Entreprise"
        Me.GestionControles1.TableListeChoix = "ListeChoix"
        Me.GestionControles1.TableParam = "Niveau2"
        Me.GestionControles1.TexteLeft = 115
        Me.GestionControles1.TypeRecherche = False
        '
        'GradientCaption1
        '
        Me.GradientCaption1.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GradientCaption1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption1.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(465, 24)
        Me.GradientCaption1.TabIndex = 1
        Me.GradientCaption1.Text = "Informations générales"
        '
        'GradientCaption2
        '
        Me.GradientCaption2.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption2.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption2.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption2.Name = "GradientCaption2"
        Me.GradientCaption2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption2.Size = New System.Drawing.Size(360, 24)
        Me.GradientCaption2.TabIndex = 1
        Me.GradientCaption2.Text = "Coordonnées"
        '
        'GradientCaption3
        '
        Me.GradientCaption3.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption3.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption3.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption3.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption3.Name = "GradientCaption3"
        Me.GradientCaption3.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption3.Size = New System.Drawing.Size(360, 24)
        Me.GradientCaption3.TabIndex = 1
        Me.GradientCaption3.Text = "Situation"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(485, 597)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.TabAdresses)
        Me.Panel2.Controls.Add(Me.GradientCaption2)
        Me.Panel2.Location = New System.Drawing.Point(503, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(360, 284)
        Me.Panel2.TabIndex = 26
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Date"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "libelle"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "montant"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "C2"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn3.HeaderText = "Montant"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "famille"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "codeproduit"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn5.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "libelle"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Produit"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "libunite1"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn8.HeaderText = ""
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "codeproduit"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn9.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DatagridViewComboboxColumnCustom1
        '
        Me.DatagridViewComboboxColumnCustom1.DataPropertyName = "Type"
        Me.DatagridViewComboboxColumnCustom1.DisplayStyleForCurrentCellOnly = True
        Me.DatagridViewComboboxColumnCustom1.HeaderText = "Type"
        Me.DatagridViewComboboxColumnCustom1.Items.AddRange(New Object() {"Siège", "Portable", "Fax", "Téléphone", "Email", "Email1", "Email2", "Téléphone1", "Téléphone2"})
        Me.DatagridViewComboboxColumnCustom1.Name = "DatagridViewComboboxColumnCustom1"
        Me.DatagridViewComboboxColumnCustom1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DatagridViewComboboxColumnCustom1.Width = 64
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Numero"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Numero"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 65
        '
        'DataGridViewDisableButtonColumn1
        '
        Me.DataGridViewDisableButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewDisableButtonColumn1.HeaderText = ""
        Me.DataGridViewDisableButtonColumn1.Image = CType(resources.GetObject("DataGridViewDisableButtonColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewDisableButtonColumn1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DataGridViewDisableButtonColumn1.Name = "DataGridViewDisableButtonColumn1"
        Me.DataGridViewDisableButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDisableButtonColumn1.ToolTipText = "Appeller"
        Me.DataGridViewDisableButtonColumn1.Width = 30
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Controls.Add(Me.GradientCaption3)
        Me.Panel3.Location = New System.Drawing.Point(503, 327)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(360, 307)
        Me.Panel3.TabIndex = 27
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ComboBox1)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Controls.Add(Me.GradientNavigationButton1)
        Me.Panel4.Controls.Add(Me.TextBox2)
        Me.Panel4.Controls.Add(Me.TextBox3)
        Me.Panel4.Controls.Add(Me.TextBox4)
        Me.Panel4.Location = New System.Drawing.Point(6, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(265, 213)
        Me.Panel4.TabIndex = 24
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(50, 177)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(212, 21)
        Me.ComboBox1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Pays :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(204, 150)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(58, 20)
        Me.TextBox1.TabIndex = 5
        '
        'GradientNavigationButton1
        '
        Me.GradientNavigationButton1.ActiveGradientHighColor = System.Drawing.Color.White
        Me.GradientNavigationButton1.ActiveGradientLowColor = System.Drawing.Color.Moccasin
        Me.GradientNavigationButton1.ActiveOnClick = False
        Me.GradientNavigationButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientNavigationButton1.AntiAlias = True
        Me.GradientNavigationButton1.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.GradientNavigationButton1.CornerRadius = New Ascend.CornerRadius(3)
        Me.GradientNavigationButton1.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.GradientNavigationButton1.HighColorLuminance = 1.3!
        Me.GradientNavigationButton1.Image = CType(resources.GetObject("GradientNavigationButton1.Image"), System.Drawing.Image)
        Me.GradientNavigationButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GradientNavigationButton1.Location = New System.Drawing.Point(177, 150)
        Me.GradientNavigationButton1.LowColorLuminance = 1.3!
        Me.GradientNavigationButton1.Name = "GradientNavigationButton1"
        Me.GradientNavigationButton1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientNavigationButton1.Size = New System.Drawing.Size(22, 20)
        Me.GradientNavigationButton1.StayActiveAfterClick = False
        Me.GradientNavigationButton1.TabIndex = 4
        Me.GradientNavigationButton1.TabStop = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(3, 3)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(259, 141)
        Me.TextBox2.TabIndex = 0
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(3, 150)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(62, 20)
        Me.TextBox3.TabIndex = 1
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(71, 150)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 2
        '
        'RecapCompteTA
        '
        Me.RecapCompteTA.ClearBeforeFill = True
        '
        'RecapProduitsTA
        '
        Me.RecapProduitsTA.ClearBeforeFill = True
        '
        'DossiersTableAdapter
        '
        Me.DossiersTableAdapter.ClearBeforeFill = True
        '
        'NomDataGridViewTextBoxColumn
        '
        Me.NomDataGridViewTextBoxColumn.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn.Name = "NomDataGridViewTextBoxColumn"
        Me.NomDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PrenomDataGridViewTextBoxColumn
        '
        Me.PrenomDataGridViewTextBoxColumn.DataPropertyName = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn.HeaderText = "Prenom"
        Me.PrenomDataGridViewTextBoxColumn.Name = "PrenomDataGridViewTextBoxColumn"
        Me.PrenomDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FonctionDataGridViewTextBoxColumn
        '
        Me.FonctionDataGridViewTextBoxColumn.DataPropertyName = "Fonction"
        Me.FonctionDataGridViewTextBoxColumn.HeaderText = "Fonction"
        Me.FonctionDataGridViewTextBoxColumn.Name = "FonctionDataGridViewTextBoxColumn"
        Me.FonctionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EMailDataGridViewTextBoxColumn
        '
        Me.EMailDataGridViewTextBoxColumn.DataPropertyName = "EMail"
        Me.EMailDataGridViewTextBoxColumn.HeaderText = "EMail"
        Me.EMailDataGridViewTextBoxColumn.Name = "EMailDataGridViewTextBoxColumn"
        Me.EMailDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NumeroTel
        '
        Me.NumeroTel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NumeroTel.DataPropertyName = "Numero"
        Me.NumeroTel.HeaderText = "Numero"
        Me.NumeroTel.Name = "NumeroTel"
        Me.NumeroTel.ReadOnly = True
        '
        'FrEntreprise
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(871, 641)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrEntreprise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fiche Client"
        Me.TabControl1.ResumeLayout(False)
        Me.tpCompte.ResumeLayout(False)
        Me.tpCompte.PerformLayout()
        CType(Me.RecapCompteDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecapCompteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsEntreprises, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tpContacts.ResumeLayout(False)
        Me.tpContacts.PerformLayout()
        CType(Me.PersonneDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContactsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tpProds.ResumeLayout(False)
        Me.tpProds.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        CType(Me.RecapProduitsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecapProduitsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCompta.ResumeLayout(False)
        Me.tpCompta.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.BindingSourceDossiers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrigest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewAffichageMouvements, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceAffichageMouvements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabAdresses.ResumeLayout(False)
        Me.TpTel.ResumeLayout(False)
        Me.TpTel.PerformLayout()
        CType(Me.TelephoneEntrepriseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TelephoneEntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.navTels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.navTels.ResumeLayout(False)
        Me.navTels.PerformLayout()
        Me.TpAdresseFactu.ResumeLayout(False)
        Me.PanelCoordFactu.ResumeLayout(False)
        Me.PanelCoordFactu.PerformLayout()
        Me.TpAdresseL.ResumeLayout(False)
        Me.PanelCoordLiv.ResumeLayout(False)
        Me.PanelCoordLiv.PerformLayout()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Me.ds = New DataSet

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)
            If FrApplication.Modules.ModuleCompta Then Compta.ChargerDonneesCompta(ds)
            If FrApplication.Modules.ModuleTarif Then s.Fill(ds, "Tarif")
            s.Fill(ds, "TVA")

            If CInt(Me.id) >= 0 Then
                Dim where As String = String.Format("nEntreprise={0}", Me.id)
                DefinitionDonnees.Instance.Fill(ds, "Entreprise", s)
                DefinitionDonnees.Instance.Fill(ds, "TelephoneEntreprise", s, where)
                DefinitionDonnees.Instance.Fill(ds, "Personne", s, "(" & where & " OR TypePersonne = 'Commercial') AND npAfficher=0")
                Me.ds.AcceptChanges()
                With Me.EntrepriseBindingSource
                    .DataSource = ds
                    .DataMember = "Entreprise"
                End With
                Me.EntrepriseBindingSource.Filter = where
            ElseIf AjouterEnregistrement Then
                If FrApplication.Parametres.TesterLimiteDemoClient(Me.EntrepriseBindingSource.Count) Then
                    DefinitionDonnees.Instance.Fill(ds, "Entreprise", s)
                    DefinitionDonnees.Instance.FillSchema(ds, "TelephoneEntreprise", s)
                    DefinitionDonnees.Instance.Fill(ds, "Personne", s, "TypePersonne = 'Commercial' AND npAfficher=0")
                    With Me.EntrepriseBindingSource
                        .DataSource = ds
                        .DataMember = "Entreprise"
                    End With
                    Me.EntrepriseBindingSource.AddNew()
                    ValeurDefautEntreprise(Me.CurrentDrv, s)
                End If
            End If
        End Using
        DefinitionDonnees.Instance.CreateRelations(ds)
        ConfigDataTableEvents(Me.ds.Tables("Entreprise"), AddressOf Datarowchanged, True)
        ConfigDataTableEvents(Me.ds.Tables("Personne"), AddressOf Datarowchanged, True)
        ConfigDataTableEvents(Me.ds.Tables("TelephoneEntreprise"), AddressOf Datarowchanged, False)
        Databinding()
    End Sub

    Private Sub ChargerContacts()
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub
        Using s As New SqlProxy
            If CInt(Me.nEntreprise) >= 0 Then
                DefinitionDonnees.Instance.Fill(ds, "Personne", s, String.Format("nEntreprise={0}", Me.nEntreprise))
            End If
        End Using
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Rollback
                MajBoutons()
        End Select
    End Sub

    Private Sub Databinding()
        With Me.ContactsBindingSource
            .SuspendBinding()
            .DataSource = Me.EntrepriseBindingSource
            .DataMember = "EntrepriseContact"
            .ResumeBinding()
        End With
        With Me.TelephoneEntrepriseBindingSource
            .SuspendBinding()
            .DataSource = Me.EntrepriseBindingSource
            .DataMember = "EntrepriseTelephone"
            .ResumeBinding()
        End With
        Me.TelephoneEntrepriseDataGridView.DataSource = Me.TelephoneEntrepriseBindingSource

        'Databinding
        Me.GestionControles1.SetDataSource(CType(Me.EntrepriseBindingSource.List, DataView))
        Me.GestionControles1.SetCurrencyManager(Me.EntrepriseBindingSource.CurrencyManager)
        'Me.GestionAdresseIIFact.db = Me.EntrepriseBindingSource.CurrencyManager
        'Me.GestionAdresseIILiv.db = Me.EntrepriseBindingSource.CurrencyManager

        'Coordonnées Facturation
        Me.TextBoxAdresseFactu.DataBindings.Add("Text", Me.EntrepriseBindingSource, "Adresse")
        Me.TextBoxCPFactu.DataBindings.Add("Text", Me.EntrepriseBindingSource, "CodePostal")
        Me.TextBoxVilleFactu.DataBindings.Add("Text", Me.EntrepriseBindingSource, "Ville")
        Me.TextBoxSuffixeFactu.DataBindings.Add("Text", Me.EntrepriseBindingSource, "SuffixePostal")
        Me.ComboBoxPaysFactu.DataBindings.Add("Text", Me.EntrepriseBindingSource, "Pays")

        'Coordonnées Livraison
        Me.TextBoxAdresseLiv.DataBindings.Add("Text", Me.EntrepriseBindingSource, "AdresseLiv")
        Me.TextBoxCPLiv.DataBindings.Add("Text", Me.EntrepriseBindingSource, "CodePostalLiv")
        Me.TextBoxVilleLiv.DataBindings.Add("Text", Me.EntrepriseBindingSource, "VilleLiv")
        'Me.TextBoxSuffixeLiv.DataBindings.Add("Text", Me.EntrepriseBindingSource, "SuffixePostalLiv")
        Me.ComboBoxPaysLiv.DataBindings.Add("Text", Me.EntrepriseBindingSource, "PaysLiv")

        If FrApplication.Modules.ModuleCompta Then GestCompta = New Compta(ds, Me.EntrepriseBindingSource.CurrencyManager, "Nom")

        'AfficheStatistique()
        AfficheCompteClient()
        AfficheProduits()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Dim c As New System.ComponentModel.CancelEventArgs
        DemanderEnregistrement(c)
        Return Not c.Cancel
    End Function

    Private Shadows Function Validate() As Boolean
        Dim res As Boolean
        res = Me.GestionControles1.VerifContraintes
        If res Then
            res = MyBase.Validate()
        End If
        Return res
    End Function

    Private Sub DemanderEnregistrement(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = Not Me.Validate()
        If e.Cancel Then
            If Not Me.ds.HasChanges Then
                e.Cancel = False  'Pour sortir sans enregistrer
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        Me.TelephoneEntrepriseBindingSource.EndEdit()
        Me.EntrepriseBindingSource.EndEdit()
        If Me.ds.HasChanges Then
            Select Case MsgBox("Voulez-vous enregistrer les modifications ?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Cancel
                    e.Cancel = True
                Case MsgBoxResult.No
                    'On continue sans enregistrer
                Case MsgBoxResult.Yes
                    If Not Enregistrer() Then
                        e.Cancel = True
                    End If
            End Select
        End If
    End Sub

    Private Function Enregistrer() As Boolean
        'Enregistrer
        If Not Me.Validate() Then Return False
        Me.TelephoneEntrepriseBindingSource.EndEdit()
        Me.EntrepriseBindingSource.EndEdit()

        Return UpdateBase()
    End Function

    Private Function UpdateBase() As Boolean
        Try
            Dim strNomTable() As String = {"Entreprise", "Personne", "TelephoneEntreprise"} ', "ListeChoix", "Evenement", "EvenementPersonne", "EvenementPiece"}
            Using s As New SqlProxy
                s.UpdateTables(ds, strNomTable)
            End Using
            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub ValeurDefautEntreprise(ByRef rwv As DataRowView, ByVal s As SqlProxy)
        Dim VDef As ValeurDefaultApplication = FrApplication.ValeurDefault
        With rwv
            If GRC.FrBase.Autorisation <> "Tous" Then
                .Item("Dep") = GRC.FrBase.Autorisation
            End If
            If Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur Then
                .Item("Fournisseur") = True
                .Item("Client") = False
                .Item("FacturationTTC") = False
            Else
                .Item("Client") = True
                .Item("Fournisseur") = False
                .Item("FacturationTTC") = True
            End If
        End With
        If Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur Then
            rwv.Item("FacturationTTC") = VDef.FournisseurFacturationTTC
            If VDef.FournisseurNCompteAuto = False Then
                rwv("NCompteF") = VDef.FournisseurNCompte
            Else
                Dim maxCompte As Long = s.GetMaxValue("Entreprise", "NCompteF", "Fournisseur=1 And SUBSTRING(NCompteF,4,5)<>'99999'")
                If maxCompte > 0 Then
                    rwv("NCompteF") = maxCompte + 1
                Else
                    rwv("NCompteF") = VDef.FournisseurNCompte
                End If
            End If
            rwv.Item("NActiviteF") = VDef.FournisseurNActivite
        ElseIf Me.TypeEntreprise = FrListeClient.TypesEntreprise.Client Then
            rwv.Item("FacturationTTC") = VDef.ClientFacturationTTC
            If VDef.ClientNCompteAuto = False Then
                rwv.Item("NCompteC") = VDef.ClientNCompte
            Else
                Dim maxCompte As Long = 0

                Try
                    maxCompte = s.GetMaxValue("Entreprise", "NCompteC", "Client=1 And SUBSTRING(NCompteC,4,5)<>'99999'")
                Catch ex As Exception
                    MsgBox("Calcul automatique d'un nouveau numéro de compte client impossible. Format du dernier numéro de compte non numérique. Veuillez modifier le fichier paramètre et choisir un mode de calcul non automatique. Erreur d'origine : " & ex.Message, MsgBoxStyle.Exclamation, "Calcul automatique d'un nouveau numéro de compte client impossible.")
                End Try

                If maxCompte > 0 Then
                    'TODO : Problème : ce compte ne s'affiche pas s'il n'est pas créé dans la table Comptes (et eventuellement dans la compta)
                    rwv("NCompteC") = maxCompte + 1
                Else
                    rwv("NCompteC") = VDef.ClientNCompte
                End If
            End If
            rwv.Item("NActiviteC") = VDef.ClientNActivite
        End If
    End Sub

    Private Sub gc_MustRefreshTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles1.MustRefreshTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                ds.EnforceConstraints = False
                Using s As New SqlProxy
                    s.Fill(ds, t)
                End Using
                ds.EnforceConstraints = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gc_MustUpdateTabled(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles1.MustUpdateTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                Using s As New SqlProxy
                    s.UpdateTable(ds, t)
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Form Events"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                DemanderEnregistrement(e)
                If e.Cancel Then Exit Sub
                If Me.EntrepriseBindingSource.Position >= 0 Then
                    Me.OnSelectObject(Me.nEntreprise)
                End If
        End Select
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized

        'Gestion contrôles escompte
        Me.GererControlesEscompte()

        'Gestion NCompteC
        Me.GererNCompteC()
    End Sub

    Private Sub FrEntreprise_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.GradientPanel2.Height = Math.Max(Me.Panel1.Height, Me.GestionControles1.Height + Me.GradientCaption1.Height)
        Me.GestionControles1.Height = Me.GradientPanel2.Height - Me.GradientCaption1.Height
    End Sub

    Private Sub CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
        Me.EntrepriseBindingSource.EndEdit()
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption1)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption2)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption3)

        'Filtrage des onglets compte et produits
        ConfigDateControl(Me.TxDateDebFiltreCompte.TextBox)
        ConfigDateControl(Me.TxDateFinFiltreCompte.TextBox)
        AddHandler Me.TxDateDebFiltreCompte.LostFocus, AddressOf txDateFiltreCompte_LostFocus
        AddHandler Me.TxDateFinFiltreCompte.LostFocus, AddressOf txDateFiltreCompte_LostFocus
        ConfigDateControl(Me.TxDateDebFiltreProduits.TextBox)
        ConfigDateControl(Me.TxDateFinFiltreProduits.TextBox)
        AddHandler Me.TxDateDebFiltreProduits.LostFocus, AddressOf txDateFiltreProduits_LostFocus
        AddHandler Me.TxDateFinFiltreProduits.LostFocus, AddressOf txDateFiltreProduits_LostFocus

        Me.NEntrepriseDataGridViewTextBoxColumn.Visible = False

        AddHandler Me.GestionControles1.CtlValidated, AddressOf CtlValidated

        'Me.GestionAdresseIIFact.ConnectionString = My.Settings.DefaultConnString
        'Me.GestionAdresseIILiv.ConnectionString = My.Settings.DefaultConnString

        ApplyStyle(Me.RecapCompteDataGridView)
        ApplyStyle(Me.RecapProduitsDataGridView)
        ApplyStyle(Me.PersonneDataGridView)
        ApplyStyle(Me.TelephoneEntrepriseDataGridView, False)
        With TelephoneEntrepriseDataGridView
            AddHandler .EditingControlShowing, AddressOf MakeComboDropDown
            AddHandler .CellValidating, AddressOf cellvalidating
        End With

        Me.TelephoneEntrepriseDataGridView.DataSource = Nothing

        With FrApplication.Modules
            If Not .ModuleContact Then
                Me.TabControl1.TabPages.Remove(Me.tpContacts)
                Me.TabControl1.SelectedIndex = 0
            End If
            Me.TbMesEvents.Visible = .ModuleEvenement
        End With

        If Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur Then
            Me.Text = "Fiche Fournisseur"
            Me.TbListePiece.ToolTipText = "Consulter la liste des pièces d'achat pour ce partenaire"
        Else
            Me.Text = "Fiche Client"
            Me.TbListePiece.ToolTipText = "Consulter la liste des pièces de vente pour ce partenaire"
        End If

        Me.MesVFacturesToolStripMenuItem.Visible = (Me.TypeEntreprise = FrListeClient.TypesEntreprise.Client)
        Me.MesBonsDeCommandeToolStripMenuItem.Visible = (Me.TypeEntreprise = FrListeClient.TypesEntreprise.Client)
        Me.MesBonsDeLivraisonToolStripMenuItem.Visible = (Me.TypeEntreprise = FrListeClient.TypesEntreprise.Client)
        Me.MesDevisToolStripMenuItem.Visible = (Me.TypeEntreprise = FrListeClient.TypesEntreprise.Client)

        Me.MesBonsDeRéceptionToolStripMenuItem.Visible = (Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur)
        Me.MesAFacturesToolStripMenuItem.Visible = (Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur)
        ConfigAffichage()

        ChargerDonnees()

        GestionDesDroits()

        'Vidage des soldes de l'onglet compta 
        Me.LabelSoldeDebit.Text = String.Empty
        Me.LabelSoldeCredit.Text = String.Empty

        If FrApplication.Modules.ModuleCompta Then
            AddHandler GestionControles1.AfficheNewPerso, AddressOf GestCompta.AfficheNewPerso
            AddHandler GestionControles1.CtlValidating, AddressOf GestCompta.VerifValidating

            'Affichage des infos comptables
            ApplyStyle(Me.DataGridViewAffichageMouvements)
            Me.AfficherInfosComptables()
        End If

        MajBoutons()
    End Sub

    Private Sub GestionControles1_CtlCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestionControles1.CtlCheckedChanged
        Me.GererControlesEscompte()
    End Sub

    Private Sub GererControlesEscompte()
        Dim chkBoxIndEscompteSpecifique As CheckBox = Nothing

        For Each ctrl As Control In Me.GestionControles1.Controls(0).Controls
            If Convert.ToString(ctrl.Tag) = "IndEscompteSpecifique" Then
                chkBoxIndEscompteSpecifique = CType(ctrl, CheckBox)

                If Not (chkBoxIndEscompteSpecifique.Checked) Then
                    For Each ctrl2 As Control In Me.GestionControles1.Controls(0).Controls
                        If Convert.ToString(ctrl2.Tag) = "TauxEscompteSpecifique" Then
                            ctrl2.Enabled = False
                            ctrl2.Text = ""
                        End If

                        If Convert.ToString(ctrl2.Tag) = "DelaiValiditeEscompte" Then
                            ctrl2.Enabled = False
                            ctrl2.Text = ""
                        End If
                    Next
                Else
                    For Each ctrl2 As Control In Me.GestionControles1.Controls(0).Controls
                        If Convert.ToString(ctrl2.Tag) = "TauxEscompteSpecifique" Then
                            ctrl2.Enabled = True
                        End If

                        If Convert.ToString(ctrl2.Tag) = "DelaiValiditeEscompte" Then
                            ctrl2.Enabled = True
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub GererNCompteC()
        For Each ctrl As Control In Me.GestionControles1.Controls(0).Controls
            'Gestion de la combobox Numéro de compte
            If Convert.ToString(ctrl.Tag) = "NCompteC" Then
                Dim NCompteCComboBox As ComboBox = CType(ctrl, ComboBox)

                If CInt(Me.id) >= 0 Then
                    NCompteCComboBox.Enabled = False
                    Me.DeverrouillerNumCompteToolStripButton.Enabled = True
                Else
                    NCompteCComboBox.Enabled = True
                    Me.DeverrouillerNumCompteToolStripButton.Enabled = False
                End If
            End If

            'Gestion du bouton + associé à la combobox Numéro de compte
            If (TypeOf (ctrl.Tag) Is Hashtable) Then
                Dim tagInfo As Hashtable = CType(ctrl.Tag, Hashtable)

                If (tagInfo.ContainsKey("Champs")) Then
                    If (CStr(tagInfo.Item("Champs")) = "NCompteC") Then
                        Dim NCompteCButton As Button = CType(ctrl, Button)

                        If CInt(Me.id) >= 0 Then
                            NCompteCButton.Enabled = False
                        Else
                            NCompteCButton.Enabled = True
                        End If
                    End If
                End If
            End If
        Next
    End Sub
#End Region

#Region "Gestion de la combobox du Type de téléphone"
    Private Sub MakeComboDropDown(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
        If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
            Dim grid As DataGridView = CType(sender, DataGridView)
            Dim cmb As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
            cmb.DropDownStyle = ComboBoxStyle.DropDown
            Dim value As String = Convert.ToString(grid.CurrentCell.Value)
            If cmb.Items.IndexOf(value) = -1 Then
                cmb.Items.Add(value)
                Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.CurrentCell.OwningColumn, DataGridViewComboBoxColumn)
                If cmbCol IsNot Nothing Then cmbCol.Items.Add(value)
            End If
        End If
    End Sub

    Private Sub cellvalidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs)
        If e.ColumnIndex = Me.TypeDataGridViewTextBoxColumn.Index Then
            Dim grid As DataGridView = CType(sender, DataGridView)
            If TypeOf grid.EditingControl Is DataGridViewComboBoxEditingControl Then
                Dim cmb As DataGridViewComboBoxEditingControl = CType(grid.EditingControl, DataGridViewComboBoxEditingControl)
                Dim value As String = cmb.Text
                If cmb.Items.IndexOf(value) = -1 Then
                    cmb.Items.Add(value)
                    Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(e.ColumnIndex), DataGridViewComboBoxColumn)
                    If cmbCol IsNot Nothing Then cmbCol.Items.Add(value)
                End If
                grid.CurrentCell.Value = value
            End If
        ElseIf e.ColumnIndex = Me.NumeroDataGridViewTextBoxColumn.Index Then
            Dim grid As DataGridView = CType(sender, DataGridView)
            Dim r As DataGridViewRow = grid.Rows(e.RowIndex)
            Dim cell As DataGridViewDisableButtonCell = Cast(Of DataGridViewDisableButtonCell)(r.Cells(Me.ColTel.Index))
            cell.ButtonVisible = Convert.ToString(e.FormattedValue).Length > 0
        End If
    End Sub

    Private Sub TelephoneEntrepriseDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles TelephoneEntrepriseDataGridView.DataBindingComplete
        If e.ListChangedType <> System.ComponentModel.ListChangedType.Reset Then Exit Sub
        For Each r As DataGridViewRow In Me.TelephoneEntrepriseDataGridView.Rows
            Dim cell As DataGridViewDisableButtonCell = Cast(Of DataGridViewDisableButtonCell)(r.Cells(Me.ColTel.Index))
            Dim vis As Boolean = False
            If r.DataBoundItem IsNot Nothing Then
                If TypeOf r.DataBoundItem Is DataRowView Then
                    If Convert.ToString(Cast(Of DataRowView)(r.DataBoundItem)("Numero")).Length > 0 Then
                        vis = True
                    End If
                End If
            End If
            cell.ButtonVisible = vis
        Next
    End Sub

    Private Sub TelephoneEntrepriseDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TelephoneEntrepriseDataGridView.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex <> ColTel.Index Then Exit Sub
        Dim r As DataGridViewRow = TelephoneEntrepriseDataGridView.Rows(e.RowIndex)
        If r.DataBoundItem Is Nothing Then Exit Sub
        If Cast(Of DataRowView)(r.DataBoundItem).IsNew Then Exit Sub
        Dim drTel As DataRow = Cast(Of DataRowView)(r.DataBoundItem).Row
        If Convert.ToString(drTel("Numero")).Length = 0 Then Exit Sub
        'TODO APPELLER NUMERO
        MsgBox(String.Format("Appeller le {0}", drTel("Numero")))
    End Sub
#End Region

    '#Region "Statistiques"
    '    Private Sub AddValeurMois(ByVal nMois As Integer)
    '        Dim stat As New Statistiques
    '        With stat
    '            .ds = Me.ds
    '            .nClient = Me.nEntreprise
    '        End With

    '        Dim br As New Actigram.Windows.Forms.Indicateurs.Barre
    '        With br
    '            .Valeur = stat.GetMontant("VFacture", StatistiquesType.Mois, StatistiquesTypeMontant.TTC, Now.AddMonths(nMois))
    '            .Couleur = Color.Red
    '            .Valeur2 = stat.GetMontantPaye("VFacture", StatistiquesType.Mois, StatistiquesTypeMontant.TTC, Now.AddMonths(nMois))
    '            .Couleur2 = Color.Blue
    '        End With
    '        Me.Graphique1.Valeurs.Add(br)
    '        Me.Graphique1.Legendes.Add(Now.AddMonths(nMois).ToString("MMMM"))
    '    End Sub

    '    Private Sub AddValeurAnnees(ByVal nAnnees As Integer)
    '        Dim stat As New Statistiques
    '        With stat
    '            .ds = Me.ds
    '            .nClient = Me.nEntreprise
    '        End With

    '        Dim br As New Actigram.Windows.Forms.Indicateurs.Barre
    '        With br
    '            .Valeur = stat.GetMontant("VFacture", StatistiquesType.Mois, StatistiquesTypeMontant.TTC, Now.AddYears(nAnnees))
    '            .Couleur = Color.Red
    '            .Valeur2 = stat.GetMontantPaye("VFacture", StatistiquesType.Mois, StatistiquesTypeMontant.TTC, Now.AddYears(nAnnees))
    '            .Couleur2 = Color.Blue
    '        End With
    '        Me.Graphique1.Valeurs.Add(br)
    '        Me.Graphique1.Legendes.Add(Now.AddYears(nAnnees).Year.ToString)
    '    End Sub

    '    Private Sub RefreshGraphiqueMois()
    '        Me.Graphique1.LargeurBarre = 15
    '        For i As Integer = -5 To 0
    '            AddValeurMois(i)
    '        Next
    '    End Sub

    '    Private Sub RefreshGraphiqueAnnee()
    '        Me.Graphique1.LargeurBarre = 50

    '        AddValeurAnnees(-1)
    '        AddValeurAnnees(0)

    '    End Sub

    '    Private Sub AfficheStatistique()
    '        Exit Sub
    '        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub

    '        With Me.Graphique1
    '            .RefreshAuto = False
    '            .Legendes.Clear()
    '            .Valeurs.Clear()
    '        End With

    '        If Me.GbMois.Active Then
    '            RefreshGraphiqueMois()
    '        Else
    '            RefreshGraphiqueAnnee()
    '        End If

    '        Me.Graphique1.RefreshAuto = True

    '        Dim stat As New Statistiques
    '        stat.ds = ds
    '        stat.nClient = Me.nEntreprise

    '        Dim Ca As Decimal = stat.GetMontant("VFacture", StatistiquesType.Annee, StatistiquesTypeMontant.TTC)
    '        If Ca <> 0 Then
    '            Me.LbCA.Text = "CA : " & Ca.ToString("# ##0.00 €")
    '        Else
    '            Me.LbCA.Text = "CA :"
    '        End If
    '        Dim CaPaye As Decimal = stat.GetMontantPaye("VFacture", StatistiquesType.Annee, StatistiquesTypeMontant.TTC)
    '        If (Ca - CaPaye) <> 0 Then
    '            Me.LbEnCours.Text = "En Cours : " & (Ca - CaPaye).ToString("# ##0.00 €")
    '        Else
    '            Me.LbEnCours.Text = "En Cours : "
    '        End If

    '        Dim DerCmd As Object
    '        DerCmd = ds.Tables("VBonCommande").Compute("Max(DateFacture)", "nClient=" & Me.nEntreprise)
    '        If Not DerCmd Is DBNull.Value Then
    '            Me.LbDerCmd.Text = "Der Cmd : " & Convert.ToDateTime(DerCmd).ToString("dd/MM/yy")
    '        Else
    '            Me.LbDerCmd.Text = "Der Cmd :"
    '        End If
    '    End Sub

    '    Private Sub Graphique1_ClickLegende(ByVal sender As Actigram.Windows.Forms.Indicateurs.Graphique, ByVal nBarre As Integer)
    '        If sender.Valeurs.Item(nBarre).Valeur <> 0 Then
    '            Me.LbCA.Text = "CA (" & sender.Legendes.Item(nBarre) & ") : " & sender.Valeurs.Item(nBarre).Valeur.ToString("# ##0.00 €")
    '        Else
    '            Me.LbCA.Text = "CA (" & sender.Legendes.Item(nBarre) & ") :"
    '        End If
    '        If sender.Valeurs.Item(nBarre).Valeur2 <> 0 Then
    '            Me.LbEnCours.Text = "En Cours (" & sender.Legendes.Item(nBarre) & ") : " & (sender.Valeurs.Item(nBarre).Valeur - sender.Valeurs.Item(nBarre).Valeur2).ToString("# ##0.00 €")
    '        Else
    '            Me.LbEnCours.Text = "En Cours (" & sender.Legendes.Item(nBarre) & ") :"
    '        End If
    '    End Sub

    '    Private Sub GbMois_ActiveChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Dim gb As Ascend.Windows.Forms.GradientNavigationButton = Cast(Of Ascend.Windows.Forms.GradientNavigationButton)(sender)
    '        If Not gb.Active Then Exit Sub
    '        If sender Is Me.GbMois Then
    '            GbAnnee.Active = False
    '        Else
    '            GbMois.Active = False
    '        End If
    '        Me.AfficheStatistique()
    '    End Sub
    '#End Region

#Region "Compte client"
    Private Sub AfficheCompteClient(Optional ByVal dtDeb As Date = #1/1/2000#, Optional ByVal dtFin As Date = #1/1/2100#)
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub
        Dim nEntr As Integer = CInt(Me.nEntreprise)
        Me.RecapCompteTA.FillByNEntreprise(Me.DsEntreprises.RecapCompte, nEntr, dtDeb.Date, dtFin.Date.AddDays(1))
        Dim o As Object = Me.DsEntreprises.RecapCompte.Compute("Sum(Montant)", "")
        If Not IsDBNull(o) Then
            lbTotal.Text = String.Format("{0:C2}", o)
        Else
            lbTotal.Text = ""
        End If
    End Sub

    Private Sub RecapCompteDataGridView_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles RecapCompteDataGridView.CellContentDoubleClick
        If RecapCompteBindingSource.Position < 0 Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub
        Dim dr As DsEntreprises.RecapCompteRow = CType(CType(RecapCompteBindingSource.Current, DataRowView).Row, DsEntreprises.RecapCompteRow)
        Select Case dr.Type
            Case "F"
                Dim fr As New FrBonCommande(CInt(dr.Id))
                fr.TypePiece = Pieces.TypePieces.VFacture
                fr.FiltreType = String.Format("nClient={0}", Me.nEntreprise)
                fr.ShowDialog()
            Case "R"
                Dim fr As New FrReglement(CInt(dr.Id))
                fr.ShowDialog()
        End Select
    End Sub

    Private Sub RecapCompteDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles RecapCompteDataGridView.DataBindingComplete
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            For Each r As DataGridViewRow In RecapCompteDataGridView.Rows
                If r.DataBoundItem Is Nothing Then Continue For
                Dim dr As DsEntreprises.RecapCompteRow = CType(CType(r.DataBoundItem, DataRowView).Row, DsEntreprises.RecapCompteRow)
                If Not dr.traite Then r.DefaultCellStyle.ForeColor = Color.Red
            Next
        End If
    End Sub
#End Region

#Region "Stats Produits"
    Private Sub RecapProduitsDataGridView_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles RecapProduitsDataGridView.CellContentDoubleClick
        'Ouvrir la fiche produit
        If e.RowIndex < 0 Then Exit Sub
        Dim r As DataGridViewRow = RecapProduitsDataGridView.Rows(e.RowIndex)
        If r.DataBoundItem Is Nothing Then Exit Sub
        Dim dr As DsEntreprises.RecapProduitsRow = Cast(Of DsEntreprises.RecapProduitsRow)(Cast(Of DataRowView)(r.DataBoundItem).Row)
        Using fr As New FrProduit(dr.codeproduit)
            fr.ShowDialog()
        End Using
    End Sub

    Private Sub AfficheProduits(Optional ByVal dtDeb As Date = #1/1/2000#, Optional ByVal dtFin As Date = #1/1/2100#)
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub
        Dim nEntr As Integer = CInt(Me.nEntreprise)
        Me.RecapProduitsTA.FillByNEntreprise(Me.DsEntreprises.RecapProduits, nEntr, dtDeb.Date, dtFin.Date.AddDays(1))
    End Sub
#End Region

#Region "Contacts"
    Private Sub TbNewContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNewContact.Click
        'On enregistre les modifs de l'entreprise
        If Not DemanderEnregistrement() Then Exit Sub
        With New FrPersonne(CInt(Me.nEntreprise), True)
            AddHandler .FormClosed, AddressOf RefreshContacts
            .Show(Me)
        End With
    End Sub

    Private Sub TbSupprContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSupprContact.Click
        Me.ContactsBindingSource.EndEdit()
        Try
            Me.ContactsBindingSource.RemoveCurrent()
        Catch ex As UserCancelledException
        End Try
    End Sub

    Private Sub PersonneDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PersonneDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim dr As DataRow = CType(ContactsBindingSource.Current, DataRowView).Row
        With New FrPersonne(CInt(dr("nPersonne")))
            AddHandler .FormClosed, AddressOf RefreshContacts
            .Show(Me)
        End With
    End Sub

    Private Sub RefreshContacts(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If e.CloseReason = CloseReason.UserClosing Then
            ChargerContacts()
        End If
    End Sub

#End Region

#Region "Compta"
    Private Sub ButtonFiltrerMouvementsCompta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFiltrerMouvementsCompta.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.FiltrerMouvementsCompta()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FiltrerMouvementsCompta()
        Dim filtre As String = String.Empty
        Dim listeCriteres As New List(Of String)
        Dim i As Integer = 0

        If (Me.ComboBoxFiltreDossier.SelectedIndex > -1) Then
            listeCriteres.Add(String.Format("MDossier='{0}'", Replace(Me.ComboBoxFiltreDossier.SelectedValue.ToString(), "'", "''")))
        End If

        Select Case Me.ComboBoxFiltreLettrage.SelectedIndex
            Case 1 'Non lettrées
                listeCriteres.Add("(Mlettrage IS NULL OR MLettrage = '')")
            Case 2 'Lettrées
                listeCriteres.Add("(Mlettrage IS NOT NULL)")
        End Select

        'Construction du filtre
        If (listeCriteres.Count > 0) Then
            filtre = listeCriteres.Item(0)

            For i = 1 To listeCriteres.Count - 1
                filtre = filtre & " AND " & listeCriteres.Item(i)
            Next
        End If

        Me.BindingSourceAffichageMouvements.Filter = filtre

        Me.BindingSourceAffichageMouvements.ResetBindings(False)

        'Recalcul du solde
        Me.CalculerSoldeMouvementsCompta()
    End Sub

    Private Sub CalculerSoldeMouvementsCompta()
        Dim soldeCompte As Decimal = 0

        Me.LabelSoldeDebit.Text = ""
        Me.LabelSoldeCredit.Text = ""

        soldeCompte = Me.TotalDebitsDataGridViewAffichageMouvements - Me.TotalCreditsDataGridViewAffichageMouvements

        If (soldeCompte > 0) Then
            Me.LabelSoldeDebit.Text = String.Format("{0:C2}", soldeCompte)
        ElseIf (soldeCompte < 0) Then
            Me.LabelSoldeCredit.Text = String.Format("{0:C2}", soldeCompte)
        End If
    End Sub

    Private Function TotalDebitsDataGridViewAffichageMouvements() As Decimal
        Dim affichageMouvementsDR As DsAgrigest.AffichageMouvementsRow
        Dim sommeDebits As Decimal = 0

        For Each affichageMouvementsDRV As DataRowView In Me.BindingSourceAffichageMouvements
            affichageMouvementsDR = CType(affichageMouvementsDRV.Row, DsAgrigest.AffichageMouvementsRow)

            If Not (affichageMouvementsDR.IsMMtDebNull) Then
                sommeDebits = sommeDebits + affichageMouvementsDR.MMtDeb
            End If
        Next

        Return sommeDebits
    End Function

    Private Function TotalCreditsDataGridViewAffichageMouvements() As Decimal
        Dim affichageMouvementsDR As DsAgrigest.AffichageMouvementsRow
        Dim sommeCredits As Decimal = 0

        For Each affichageMouvementsDRV As DataRowView In Me.BindingSourceAffichageMouvements
            affichageMouvementsDR = CType(affichageMouvementsDRV.Row, DsAgrigest.AffichageMouvementsRow)

            If Not (affichageMouvementsDR.IsMMtCreNull) Then
                sommeCredits = sommeCredits + affichageMouvementsDR.MMtCre
            End If
        Next

        Return sommeCredits
    End Function

    Private Sub AfficherInfosComptables()
        Select Case Compta.ModeCompta
            Case Compta.ModesCompta.Agrigest2, Compta.ModesCompta.AgrigestEDI
                If (Not (Me.CurrentDrv("nEntreprise") Is Nothing) And (Compta.CheminBaseAgrigest <> String.Empty)) Then
                    Dim numCompte As String = String.Empty

                    'Recherche du numéro de compte du tiers
                    Using entrepriseTA As New DsAgrifactTableAdapters.EntrepriseTA
                        Dim entrepriseDT As DsAgrifact.EntrepriseDataTable = entrepriseTA.GetDataBynEntreprise(CDec(Me.CurrentDrv("nEntreprise")))

                        For Each entrepriseDR As DsAgrifact.EntrepriseRow In entrepriseDT
                            Select Case Me.TypeEntreprise
                                Case FrListeClient.TypesEntreprise.Client
                                    If Not (entrepriseDR.IsNCompteCNull) Then
                                        numCompte = entrepriseDR.NCompteC
                                    End If
                                Case FrListeClient.TypesEntreprise.Fournisseur
                                    If Not (entrepriseDR.IsNCompteFNull) Then
                                        numCompte = entrepriseDR.NCompteF
                                    End If
                            End Select
                        Next
                    End Using

                    If (numCompte <> String.Empty) Then
                        Dim connStringAgrigest As String = String.Empty

                        connStringAgrigest = String.Format("Data Source=""{0}"";Provider=""Microsoft.Jet.OLEDB.4.0""", Compta.CheminBaseAgrigest)

                        Using oleDbConnAgrigest As New OleDb.OleDbConnection(connStringAgrigest)
                            oleDbConnAgrigest.Open()

                            Using affichageMouvementsTA As New DsAgrigestTableAdapters.AffichageMouvementsTableAdapter
                                affichageMouvementsTA.Connection = oleDbConnAgrigest

                                'Recherche des mouvements pour le compte du tiers
                                affichageMouvementsTA.FillByMCpt(Me.DsAgrigest.AffichageMouvements, numCompte)
                            End Using

                            Me.DossiersTableAdapter.Connection = oleDbConnAgrigest
                            Me.DossiersTableAdapter.Fill(Me.DsAgrigest.Dossiers)

                            Me.BindingSourceDossiers.Sort = "DDtDebEx DESC"

                            'Filtrage des mouvements
                            Me.FiltrerMouvementsCompta()
                        End Using
                    End If
                End If
        End Select
    End Sub
#End Region

#Region "Gestion des menus contextuels"
    Private Sub TbMesEvents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MesÉvènementsToolStripMenuItem.Click
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub
        If Not DemanderEnregistrement() Then Exit Sub
        Dim fr As New FrAgenda("Entreprise", CInt(Me.nEntreprise))
        fr.Owner = Me
        fr.Show()
    End Sub

    Private Sub TbNewEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouvelÉvènementToolStripMenuItem.Click
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub
        If Not DemanderEnregistrement() Then Exit Sub

        Dim fr As New FrEvenement(CInt(Me.nEntreprise), "Entreprise", "nEntreprise")
        fr.Owner = Me
        fr.Show()
    End Sub

    Private Sub ListePiecesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MesVFacturesToolStripMenuItem.Click, MesBonsDeCommandeToolStripMenuItem.Click, MesBonsDeLivraisonToolStripMenuItem.Click, MesDevisToolStripMenuItem.Click, MesAFacturesToolStripMenuItem.Click, MesBonsDeRéceptionToolStripMenuItem.Click
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub
        'Commencer par enregistrer l'entreprise en cours
        If Not DemanderEnregistrement() Then Exit Sub

        Dim typePiece As String = CStr(IIf(Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur, "A", "V"))

        With New FrListePieces2("", True)
            .nClient = CInt(Me.nEntreprise)
            .TypePiece = EnumParse(Of Pieces.TypePieces)(Convert.ToString(CType(sender, ToolStripItem).Tag))
            .Show(Me)
        End With
    End Sub

    Private Sub NouvellePieceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NouvelleVFactureToolStripMenuItem.Click, NouveauBonDeCommandeToolStripMenuItem.Click, NouveauBonDeLivraisonToolStripMenuItem.Click, NouveauDevisToolStripMenuItem.Click, NouvelleAFactureToolStripMenuItem.Click, NouveauBonDeRéceptionToolStripMenuItem.Click
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub
        'Commencer par enregistrer l'entreprise en cours
        If Not DemanderEnregistrement() Then Exit Sub

        Dim typePiece As String = CStr(IIf(Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur, "A", "V"))
        With New FrBonCommande(True, CInt(Me.nEntreprise), Nothing)
            .TypePiece = EnumParse(Of Pieces.TypePieces)(Convert.ToString(CType(sender, ToolStripItem).Tag))
            .FromEntreprise = True
            .Show(Me)
        End With
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub

        If Not FrListeClient.CheckForChildObjectsSansPersonne(CDec(Me.nEntreprise)) Then Exit Sub

        Try
            Dim nEntreprise As Decimal = CDec(Me.nEntreprise)

            Me.EntrepriseBindingSource.RemoveCurrent()

            'Suppression des contacts et de leurs téléphones
            FrListeClient.SupprimerContactsDeEntreprise(nEntreprise)

            If UpdateBase() Then Me.Close()
        Catch ex As UserCancelledException
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub DeverrouillerNumCompteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeverrouillerNumCompteToolStripButton.Click
        For Each ctrl As Control In Me.GestionControles1.Controls(0).Controls
            'Gestion de la combobox Numéro de compte
            If Convert.ToString(ctrl.Tag) = "NCompteC" Then
                Dim NCompteCComboBox As ComboBox = CType(ctrl, ComboBox)

                NCompteCComboBox.Enabled = True
            End If

            'Gestion du bouton + associé à la combobox Numéro de compte
            If (TypeOf (ctrl.Tag) Is Hashtable) Then
                Dim tagInfo As Hashtable = CType(ctrl.Tag, Hashtable)

                If (tagInfo.ContainsKey("Champs")) Then
                    If (CStr(tagInfo.Item("Champs")) = "NCompteC") Then
                        Dim NCompteCButton As Button = CType(ctrl, Button)

                        NCompteCButton.Enabled = True
                    End If
                End If
            End If
        Next
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub GestionDesDroits()
        '* Gestion des Droits
        If GRC.FrBase.LstAutorisation.Contains("General") Then
            Dim Droits As Autorisations = CType(LstAutorisation("General"), Autorisations)
            Me.TbDelete.Enabled = Droits.Suppr
            Me.TbNewContact.Enabled = Droits.Ajt
            Me.TbSupprContact.Enabled = Droits.Suppr
            Me.GestionControles1.AutoriseModif = Droits.Modif
            Me.GestionControles1.AutoriseAjt = Droits.Ajt
            Me.GestionControles1.AutoriseSuppr = Droits.Suppr
            Me.TpAdresseFactu.Enabled = Droits.Modif
            Me.TpAdresseL.Enabled = Droits.Modif
            Me.TelephoneEntrepriseDataGridView.ReadOnly = Not Droits.Modif
        End If
        If GRC.FrBase.LstAutorisation.Contains("Evenement") Then
            Me.NouvelÉvènementToolStripMenuItem.Enabled = CType(LstAutorisation("Evenement"), Autorisations).Modif
        End If
    End Sub

    Private Sub ConfigAffichage()
        'Config Affichage
        Dim strFiltreAffichage As New List(Of String)
        strFiltreAffichage.Add("FiltrePlus Is Null")

        With FrApplication.Modules
            If .ModuleAchat Then strFiltreAffichage.Add("FiltrePlus='Achat'")
            If .ModuleReglement Then strFiltreAffichage.Add("FiltrePlus='Reglement'")
            If .ModuleGestionWeb Then strFiltreAffichage.Add("FiltrePlus='GestionWeb'")
            If .ModuleTarif Then strFiltreAffichage.Add("FiltrePlus='Tarif'")
        End With
        With strFiltreAffichage
            If Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur Then
                .Add("FiltrePlus='Fournisseur'")
                If FrApplication.Modules.ModuleCompta Then .Add("FiltrePlus='ComptaFournisseur'")
            Else
                .Add("FiltrePlus='Client'")
                If FrApplication.Modules.ModuleCompta Then .Add("FiltrePlus='ComptaClient'")
            End If
        End With
        Me.GestionControles1.FiltreAffichage = String.Join(" Or ", strFiltreAffichage.ToArray)
    End Sub

    Private Sub MajBoutons()
        'Me.TbSave.Enabled = Me.ds.HasChanges
        Me.TbSave.Enabled = True
        Dim rowExists As Boolean = (Me.EntrepriseBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)
        Me.TbDelete.Enabled = rowExists
        Me.TbMesEvents.Enabled = rowExists
        Me.TbListePiece.Enabled = rowExists
        Me.TbNewPiece.Enabled = rowExists
    End Sub

    Private Sub txDateFiltre_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim tx As TextBox = CType(sender, TextBox)
        tx.Text = tx.Text.Trim
        If tx.Text.Length = 0 Then
            tx.Tag = Nothing
            Exit Sub
        End If
        Dim dt As Date
        If Not Date.TryParse(tx.Text, dt) Then
            e.Cancel = True
        Else
            tx.Tag = dt
        End If
    End Sub

    Private Sub txDateFiltreCompte_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender Is Me.TxDateDebFiltreCompte.TextBox Then
            Me.TxDateDebFiltreCompte.Tag = Me.TxDateDebFiltreCompte.TextBox.Tag
        ElseIf sender Is Me.TxDateFinFiltreCompte.TextBox Then
            Me.TxDateFinFiltreCompte.Tag = Me.TxDateFinFiltreCompte.TextBox.Tag
        End If

        Dim dtDeb As Date = #1/1/2000#
        Dim dtFin As Date = #1/1/2100#
        If TxDateDebFiltreCompte.Tag IsNot Nothing AndAlso TypeOf TxDateDebFiltreCompte.Tag Is Date Then
            dtDeb = CDate(TxDateDebFiltreCompte.Tag)
        End If
        If TxDateFinFiltreCompte.Tag IsNot Nothing AndAlso TypeOf TxDateFinFiltreCompte.Tag Is Date Then
            dtFin = CDate(TxDateFinFiltreCompte.Tag)
        End If
        AfficheCompteClient(dtDeb, dtFin)
    End Sub

    Private Sub txDateFiltreProduits_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender Is Me.TxDateDebFiltreProduits.TextBox Then
            Me.TxDateDebFiltreProduits.Tag = Me.TxDateDebFiltreProduits.TextBox.Tag
        ElseIf sender Is Me.TxDateFinFiltreProduits.TextBox Then
            Me.TxDateFinFiltreProduits.Tag = Me.TxDateFinFiltreProduits.TextBox.Tag
        End If

        Dim dtDeb As Date = #1/1/2000#
        Dim dtFin As Date = #1/1/2100#
        If TxDateDebFiltreProduits.Tag IsNot Nothing AndAlso TypeOf TxDateDebFiltreProduits.Tag Is Date Then
            dtDeb = CDate(TxDateDebFiltreProduits.Tag)
        End If
        If TxDateFinFiltreProduits.Tag IsNot Nothing AndAlso TypeOf TxDateFinFiltreProduits.Tag Is Date Then
            dtFin = CDate(TxDateFinFiltreProduits.Tag)
        End If
        AfficheProduits(dtDeb, dtFin)
    End Sub

    Private Sub txDateFiltreCompte_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        Dim c As New System.ComponentModel.CancelEventArgs
        txDateFiltre_Validating(CType(sender, ToolStripTextBox).TextBox, c)
        If Not c.Cancel Then
            txDateFiltreCompte_Validated(CType(sender, ToolStripTextBox).TextBox, e)
        Else
            CType(sender, ToolStripTextBox).Focus()
        End If
    End Sub

    Private Sub txDateFiltreProduits_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        Dim c As New System.ComponentModel.CancelEventArgs
        txDateFiltre_Validating(CType(sender, ToolStripTextBox).TextBox, c)
        If Not c.Cancel Then
            txDateFiltreProduits_Validated(CType(sender, ToolStripTextBox).TextBox, e)
        Else
            CType(sender, ToolStripTextBox).Focus()
        End If
    End Sub

#End Region

    Private Sub ButtonRechercherVilleFactu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRechercherVilleFactu.Click
        Dim frS As New FrRechercheVille(Me.ds, Me.TextBoxCPFactu, Me.TextBoxVilleFactu)
        frS.ConnectionString = My.Settings.AgrifactConnString
        frS.Owner = Me.FindForm
        frS.ShowDialog()
    End Sub

    Private Sub GradientNavigationButtonRechercherVilleLiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GradientNavigationButtonRechercherVilleLiv.Click
        Dim frS As New FrRechercheVille(Me.ds, Me.TextBoxCPLiv, Me.TextBoxVilleLiv)
        frS.ConnectionString = My.Settings.AgrifactConnString
        frS.Owner = Me.FindForm
        frS.ShowDialog()
    End Sub

    'Private Sub ConfigDgContact()
    '    'ConfigDgContact
    '    Dim cl1 As New Actigram.Windows.Forms.DataGridTextBoxColumnParentRelationChampsMultiples
    '    With cl1
    '        .MappingName = "Nom"
    '        .Expression = "Nom + ' ' + Prenom"
    '        .NullText = ""
    '        .HeaderText = "Contact"
    '        .Width = 120
    '    End With

    '    Dim cl As New DataGridTextBoxColumn
    '    With cl
    '        .HeaderText = "Fonction"
    '        .NullText = ""
    '        .MappingName = "Fonction"
    '        .Width = 150
    '    End With

    '    Dim tb As New DataGridTableStyle
    '    With tb
    '        .MappingName = "Personne"
    '        .HeaderBackColor = Color.White
    '        .HeaderForeColor = Color.FromArgb(210, 0, 0)
    '        .GridColumnStyles.Add(cl1)
    '        .GridColumnStyles.Add(cl)
    '    End With

    '    With Me.dgContacts
    '        .TableStyles.Add(tb)
    '    End With
    'End Sub

    'Private Sub DuVieux()
    'If Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur Then
    '    s.FillBy(ds, "Entreprise", "Fournisseur=1")
    'Else
    '    s.FillBy(ds, "Entreprise", "Client=1")
    'End If
    's.Fill(ds, "TelephoneEntreprise")
    's.Fill(ds, "Personne")
    'Me.ds.Relations.Add("EntrepriseContact", ds.Tables("Entreprise").Columns("nEntreprise"), ds.Tables("Personne").Columns("nEntreprise"), False)
    'Me.ds.Relations.Add("EntrepriseTelephone", ds.Tables("Entreprise").Columns("nEntreprise"), ds.Tables("TelephoneEntreprise").Columns("nEntreprise"), False)


    ''Valeurs par défaut
    'With Me.ds.Tables("Entreprise")
    '    If GRC.FrBase.Autorisation <> "Tous" Then
    '        .Columns("Dep").DefaultValue = GRC.FrBase.Autorisation
    '    End If
    '    If Me.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur Then
    '        .Columns("Fournisseur").DefaultValue = True
    '        .Columns("Client").DefaultValue = False
    '        .Columns("FacturationTTC").DefaultValue = False
    '    Else
    '        .Columns("Client").DefaultValue = True
    '        .Columns("Fournisseur").DefaultValue = False
    '        .Columns("FacturationTTC").DefaultValue = True
    '    End If
    'End With
    'End Sub

    '#Region "Gestion navigation entreprises"
    '    'Private Sub ndbEntreprises_DataMove(ByVal strTable As String, ByVal intPosition As Integer)
    '    '    If Me.GestionControles1.AutoriseModif = True Then
    '    '        Me.GestionControles1.Enabled = Me.EntrepriseBindingSource.Count > 0
    '    '    End If

    '    '    If Me.TabAdresses.SelectedIndex <> 0 Then Me.TabAdresses.SelectedIndex = 0

    '    '    AfficheStatistique()
    '    '    AfficheCompteClient()
    '    '    AfficheProduits()

    '    'End Sub

    '    'Private Sub ndbEntreprises_BeforeDeleteRow(ByVal strTable As String, ByVal intPosition As Integer)
    '    '    Dim rws() As DataRow = Me.ds.Tables("TelephoneEntreprise").Select(String.Format("nEntreprise={0}", Me.nEntreprise))
    '    '    For i As Integer = 0 To rws.Length - 1
    '    '        rws(i).Delete()
    '    '    Next
    '    'End Sub

    '    'Private Sub ndbEntreprises_RemoveAt(ByVal intPosition As Integer)
    '    '    Me.EntrepriseBindingSource.EndEdit()
    '    '    FrDonnees.UpdateSQLServer(Actigram.Donnees.ConfigurationSqlServer.MethodeUpdate.Delete)
    '    'End Sub

    '    'Private Sub ndbEntreprises_BeforeAddNew(ByVal e As System.ComponentModel.CancelEventArgs)
    '    '    Me.EntrepriseBindingSource.Filter = Me.FiltreType
    '    '    e.Cancel = Not FrApplication.Parametres.TesterLimiteDemoClient(Me.EntrepriseBindingSource.Count)
    '    'End Sub

    '    'Private Sub ndbEntreprises_AddNew()
    '    '    If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub
    '    '    ValeurDefautEntreprise(Me.CurrentDrv)
    '    'End Sub

    '#End Region

End Class
