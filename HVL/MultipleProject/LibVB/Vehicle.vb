Public Class Vehicle

    Public Sub New(_brand As String, _model As String, _yr As Integer, _hk As Integer)
        brand = _brand : model = _model : yr = _yr : hk = hk
    End Sub

    REM members
    Public brand As String
    Public model As String
    Public yr As Integer
    Public hk As Integer

    Public Function Info() As String
        Return brand & "," & model & "," & yr.ToString() & "," & hk.ToString()
    End Function

End Class
