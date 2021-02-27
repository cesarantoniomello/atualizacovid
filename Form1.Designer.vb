<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmd_atualiza = New System.Windows.Forms.Button()
        Me.pbar_atualiza = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_step = New System.Windows.Forms.MaskedTextBox()
        Me.btn_mais = New System.Windows.Forms.Button()
        Me.btn_menos = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmd_atualiza
        '
        Me.cmd_atualiza.Location = New System.Drawing.Point(713, 63)
        Me.cmd_atualiza.Name = "cmd_atualiza"
        Me.cmd_atualiza.Size = New System.Drawing.Size(75, 23)
        Me.cmd_atualiza.TabIndex = 0
        Me.cmd_atualiza.Text = "Atualizar"
        Me.cmd_atualiza.UseVisualStyleBackColor = True
        '
        'pbar_atualiza
        '
        Me.pbar_atualiza.Location = New System.Drawing.Point(12, 34)
        Me.pbar_atualiza.Name = "pbar_atualiza"
        Me.pbar_atualiza.Size = New System.Drawing.Size(776, 23)
        Me.pbar_atualiza.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(388, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Step"
        '
        'txt_step
        '
        Me.txt_step.Location = New System.Drawing.Point(423, 66)
        Me.txt_step.Mask = "00000"
        Me.txt_step.Name = "txt_step"
        Me.txt_step.ReadOnly = True
        Me.txt_step.Size = New System.Drawing.Size(100, 20)
        Me.txt_step.TabIndex = 4
        Me.txt_step.Text = "500"
        Me.txt_step.ValidatingType = GetType(Integer)
        '
        'btn_mais
        '
        Me.btn_mais.Location = New System.Drawing.Point(564, 64)
        Me.btn_mais.Name = "btn_mais"
        Me.btn_mais.Size = New System.Drawing.Size(31, 23)
        Me.btn_mais.TabIndex = 5
        Me.btn_mais.Text = ">>"
        Me.btn_mais.UseVisualStyleBackColor = True
        '
        'btn_menos
        '
        Me.btn_menos.Location = New System.Drawing.Point(529, 63)
        Me.btn_menos.Name = "btn_menos"
        Me.btn_menos.Size = New System.Drawing.Size(29, 23)
        Me.btn_menos.TabIndex = 6
        Me.btn_menos.Text = "<<"
        Me.btn_menos.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 105)
        Me.Controls.Add(Me.btn_menos)
        Me.Controls.Add(Me.btn_mais)
        Me.Controls.Add(Me.txt_step)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbar_atualiza)
        Me.Controls.Add(Me.cmd_atualiza)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmd_atualiza As Button
    Friend WithEvents pbar_atualiza As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_step As MaskedTextBox
    Friend WithEvents btn_mais As Button
    Friend WithEvents btn_menos As Button
End Class
