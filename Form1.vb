
Public Class Form1
    Dim conn As ADODB.Connection
    Private Sub cmd_atualiza_Click(sender As Object, e As EventArgs) Handles cmd_atualiza.Click
        Me.Text = "Lendo Valores"


        Dim textocompleto As String
        Dim linhas
        Dim linhatexto
        Dim valores
        Dim strcon
        Dim idadeoriginal
        Dim DATA_INICIO_SINTOMAS
        Dim DATA_OBITO
        Dim DATA_OBITO_DIVULGACAO
        Dim DATA_RECUPERADO_DIVULGACAO
        Dim strsql
        Dim contador
        conn = New ADODB.Connection
        contador = 0
        Me.Text = "Baixando Arquivo Decimal Dados"
        Try
            'My.Computer.FileSystem.DeleteFile("C:\temp\covid.csv")
            My.Computer.Network.DownloadFile("https://www.saude.pr.gov.br/sites/default/arquivos_restritos/files/documento/2021-02/informe_epidemiologico_26_02_2021_geral.csv", "C:\Temp\covid2.csv")
        Catch ex As Exception

        End Try
        Me.Text = "Lendo arquivo do HD"
        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\temp\covid2.csv", System.Text.Encoding.Default)

        textocompleto = fileReader.ReadToEnd
        strcon = "DRIVER=MySQL ODBC 3.51 Driver; SERVER=localhost;DATABASE=covid; UID=covid;PASSWORD=covid;OPTION=" & 1 + 2 + 8 + 32 + 2048 + 16384
        conn.Open(strcon)
        Me.Text = "Parsando arquivo na memoria"
        linhas = Split(textocompleto, vbCrLf)
        strsql = "INSERT INTO geral2 (`IBGE_RES_PR`,`IBGE_ATEND_PR`,`SEXO`,`IDADE_ORIGINAL`,`MUN_RESIDENCIA`,`MUN_ATENDIMENTO`,`LABORATORIO`,`DATA_DIAGNOSTICO`,`DATA_CONFIRMACAO_DIVULGACAO`,`DATA_INICIO_SINTOMAS`,`OBITO`,`DATA_OBITO`,`DATA_OBITO_DIVULGACAO`,`STATUS`,`DATA_RECUPERADO_DIVULGACAO`,`FONTE_DADO_RECUPERADO`) VALUES "
        pbar_atualiza.Maximum = UBound(linhas) - 1
        For i = 1 To UBound(linhas) - 1


            linhatexto = linhas(i)
            valores = Split(linhatexto, ";")
            If IsNumeric(valores(3)) Then idadeoriginal = valores(3).ToString.Replace(Chr(34), "") Else idadeoriginal = ""
            If IsDate(valores(9).ToString.Replace(Chr(34), "")) Then DATA_INICIO_SINTOMAS = "'" & Format(CDate(valores(9).ToString.Replace(Chr(34), "")), "yyyy-MM-dd") & "'" Else DATA_INICIO_SINTOMAS = "NULL"
            If IsDate(valores(11).ToString.Replace(Chr(34), "")) Then DATA_OBITO = "'" & Format(CDate(valores(11).ToString.Replace(Chr(34), "")), "yyyy-MM-dd") & "'" Else DATA_OBITO = "NULL"
            If IsDate(valores(12).ToString.Replace(Chr(34), "")) Then DATA_OBITO_DIVULGACAO = "'" & Format(CDate(valores(12).ToString.Replace(Chr(34), "")), "yyyy-MM-dd") & "'" Else DATA_OBITO_DIVULGACAO = "NULL"
            If IsDate(valores(14).ToString.Replace(Chr(34), "")) Then DATA_RECUPERADO_DIVULGACAO = "'" & Format(CDate(valores(14).ToString.Replace(Chr(34), "")), "yyyy-MM-dd") & "'" Else DATA_RECUPERADO_DIVULGACAO = "NULL"


            strsql = strsql _
            & "(" & valores(0).ToString.Replace(Chr(34), "") _
            & "," & valores(1).ToString.Replace(Chr(34), "") _
            & ",'" & valores(2).ToString.Replace(Chr(34), "") & "'" _
            & "," & idadeoriginal _
            & ",'" & valores(4).ToString.Replace("'", "\'") & "'" _
            & ",'" & valores(5).ToString.Replace("'", "\'") & "'" _
            & ",'" & valores(6).ToString.Replace(Chr(34), "") & "'" _
            & ",'" & Format(CDate(valores(7).ToString.Replace(Chr(34), "")), "yyyy-MM-dd") & "'" _
            & ",'" & Format(CDate(valores(8).ToString.Replace(Chr(34), "")), "yyyy-MM-dd") & "'" _
            & "," & DATA_INICIO_SINTOMAS _
            & ",'" & valores(10).ToString.Replace(Chr(34), "") & "'" _
            & "," & DATA_OBITO _
            & "," & DATA_OBITO_DIVULGACAO _
            & ",'" & valores(13).ToString.Replace(Chr(34), "") & "'" _
            & "," & DATA_RECUPERADO_DIVULGACAO _
            & ",'" & valores(15).ToString.Replace(Chr(34), "") & "')," & vbCrLf
            contador = contador + 1
            If contador > txt_step.Text.ToString Then
                pbar_atualiza.Value = i
                Me.Text = "Gravando Dados" & i & " de " & UBound(linhas)
                strsql = Mid(strsql, 1, strsql.ToString.Length - 3)
                strsql = strsql & ";"
                conn.Execute(strsql)
                contador = 0
                strsql = "INSERT INTO geral2 (`IBGE_RES_PR`,`IBGE_ATEND_PR`,`SEXO`,`IDADE_ORIGINAL`,`MUN_RESIDENCIA`,`MUN_ATENDIMENTO`,`LABORATORIO`,`DATA_DIAGNOSTICO`,`DATA_CONFIRMACAO_DIVULGACAO`,`DATA_INICIO_SINTOMAS`,`OBITO`,`DATA_OBITO`,`DATA_OBITO_DIVULGACAO`,`STATUS`,`DATA_RECUPERADO_DIVULGACAO`,`FONTE_DADO_RECUPERADO`) VALUES "
            End If

            Application.DoEvents()

        Next
        strsql = Mid(strsql, 1, strsql.ToString.Length - 3)
        strsql = strsql & ";"
        conn.Execute(strsql)
        pbar_atualiza.Value = pbar_atualiza.Value = pbar_atualiza.Maximum
        Me.Text = "Gravando Dados" & pbar_atualiza.Value & " de " & pbar_atualiza.Maximum
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_menos_Click(sender As Object, e As EventArgs) Handles btn_menos.Click
        txt_step.Text = txt_step.Text - 10
    End Sub

    Private Sub btn_mais_Click(sender As Object, e As EventArgs) Handles btn_mais.Click
        txt_step.Text = txt_step.Text + 10
    End Sub
End Class
