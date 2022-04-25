Public Class ParamsEtat

    Private _nomEtat As String
    Public Property NomEtat() As String
        Get
            Return _nomEtat
        End Get
        Set(ByVal value As String)
            _nomEtat = value
        End Set
    End Property


    Private Sub ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImprimer.Click, BtApercu.Click

        Me.Cursor = Cursors.WaitCursor
        Dim dtDeb As Date = dtpDateDebut.Value.Date
        Dim dtFin As Date = dtpDateFin.Value.Date

        Dim dt As DataTable = Nothing
        Dim titreRapport As String = ""
        Select Case Me.NomEtat
            Case "RptEtatCaisse.rpt" : GetDataEtatCaisse(dt, titreRapport, dtDeb, dtFin)
            Case "RptCaArticle.rpt" : GetDataCaArticle(dt, titreRapport, dtDeb, dtFin)
            Case "RptJournalEncaissement.rpt" : GetDataJournalEncaissement(dt, titreRapport, dtDeb, dtFin)
        End Select

        If sender Is BtImprimer Then
            EcranCrystal.Imprimer(NomEtat, dt, titreRapport)
        Else
            EcranCrystal.Apercu(NomEtat, dt, titreRapport)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetDataEtatCaisse(ByRef dt As DataTable, ByRef titre As String, ByVal dtdeb As Date, ByVal dtfin As Date)
        Using ta As New DsEtatsTableAdapters.EtatCaisseTA
            dt = ta.GetDataByDates(dtdeb, dtfin)
        End Using
        titre = "Etat de la caisse"
        If dtdeb.Date = dtfin.Date Then
            titre = String.Format("{1} du {0:d}", dtdeb, titre)
        Else
            titre = String.Format("{2} du {0:d} au {1:d}", dtdeb, dtfin, titre)
        End If
    End Sub

    Private Sub GetDataCaArticle(ByRef dt As DataTable, ByRef titre As String, ByVal dtdeb As Date, ByVal dtfin As Date)
        Using ta As New DsEtatsTableAdapters.CAArticleTA
            dt = ta.GetData(dtdeb, dtfin)
        End Using
        titre = "CA par article comptants"
        If dtdeb.Date = dtfin.Date Then
            titre = String.Format("{1} du {0:d}", dtdeb, titre)
        Else
            titre = String.Format("{2} du {0:d} au {1:d}", dtdeb, dtfin, titre)
        End If
    End Sub

    Private Sub GetDataJournalEncaissement(ByRef dt As DataTable, ByRef titre As String, ByVal dtdeb As Date, ByVal dtfin As Date)
        Using ta As New DsEtatsTableAdapters.JournalEncaissementTA
            dt = ta.GetData(dtdeb, dtfin)
        End Using
        titre = "Journal des encaissements comptants"
        If dtdeb.Date = dtfin.Date Then
            titre = String.Format("{1} du {0:d}", dtdeb, titre)
        Else
            titre = String.Format("{2} du {0:d} au {1:d}", dtdeb, dtfin, titre)
        End If
    End Sub


    Private Sub EtatCAPrev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.CbEtats
            .BeginUpdate()
            With .Items
                .Clear()
                .Add(New ListboxItem("Etat de la caisse", "RptEtatCaisse.rpt"))
                .Add(New ListboxItem("CA par article comptants", "RptCaArticle.rpt"))
                .Add(New ListboxItem("Journal des encaissements comptants", "RptJournalEncaissement.rpt"))
            End With
            .EndUpdate()
            If Me.NomEtat Is Nothing Then
                .SelectedIndex = 0
                CbEtats_SelectedIndexChanged(Nothing, Nothing)
            End If
        End With
        Me.dtpDateDebut.Value = Today
        Me.dtpDateDebut.MaxDate = Today
        Me.dtpDateFin.Value = Today
        Me.dtpDateFin.MaxDate = Today
    End Sub

    Private Sub BtClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub dtpDateDebut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateDebut.ValueChanged
        If dtpDateFin.Value < dtpDateDebut.Value Then
            dtpDateFin.Value = dtpDateDebut.Value
        End If
    End Sub

    Private Sub dtpDateFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateFin.ValueChanged
        If dtpDateFin.Value < dtpDateDebut.Value Then
            dtpDateDebut.Value = dtpDateFin.Value
        End If
    End Sub

    Private Sub CbEtats_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbEtats.SelectedIndexChanged
        Me.NomEtat = CStr(Cast(Of ListboxItem)(Me.CbEtats.SelectedItem).Value)
    End Sub
End Class