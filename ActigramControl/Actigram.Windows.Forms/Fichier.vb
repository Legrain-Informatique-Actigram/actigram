Namespace Fichiers

    Public Class ManipulationFichier
        Public Shared Function FichierToBase64(ByVal strCheminFichier As String) As String
            Dim fl As IO.FileStream
            Try
                fl = New System.IO.FileStream(strCheminFichier, IO.FileMode.Open)
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message, "Attention", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
            Finally
                Try
                    fl = New System.IO.FileStream(strCheminFichier, IO.FileMode.Open)
                Catch ex As Exception
                    'System.Windows.Forms.MessageBox.Show(ex.Message, "Attention", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
                End Try
            End Try

            If fl Is Nothing Then Return Nothing

            Dim flReader As New System.IO.BinaryReader(fl)

            Dim bts(Convert.ToInt32(fl.Length)) As Byte
            bts = flReader.ReadBytes(Convert.ToInt32(fl.Length))

            flReader.Close()

            Return Convert.ToBase64String(bts)

        End Function

        Public Shared Sub Base64ToFichier(ByVal strBase64 As String, ByVal strCheminFichier As String)
            Dim fl As New System.IO.FileStream(strCheminFichier, IO.FileMode.Create)
            Dim flwriter As New System.IO.BinaryWriter(fl)

            flwriter.Write(Convert.FromBase64String(strBase64))
            flwriter.Close()

        End Sub

    End Class

End Namespace