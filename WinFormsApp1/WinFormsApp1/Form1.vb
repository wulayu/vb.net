Public Class Form1
    Public ContinentList As New List(Of PointF()) '用于记录所有的点
    Dim NowScale As Double
    Dim OldScale As Double
    Dim OriginPoint, Position As PointF
    Dim MousePointer As PointF
    Dim MinScale As Double = 1
    Dim ZeroMoveVector As PointF
    Dim NowOP As PointF
    Dim RealToPixel As Double
    'Dim LLScale As Double
    Dim ZoomOrNot As Boolean
    Dim ZoomMultiple As Double
    Dim DisKey, TimeKey As Boolean
    Dim DStartPoint, DEndPoint As PointF
    Dim TPoint As PointF
    Dim PointNum As Integer
    Private Sub Initial()
        OriginPoint.X = 574 \ 2 '地图中心原点
        OriginPoint.Y = 286 \ 2
        RealToPixel = 1.0 * 574 / 360
        ZoomMultiple = 1.2
        DisKey = False
        TimeKey = False
        ZoomOrNot = False
        NowScale = 1 '设定最初的比例
        OldScale = 1 '这里是为了ChangeOP函数的操作
        PointNum = 0
        ZeroMoveVector.X = 0
        ZeroMoveVector.Y = 0
        'WidthScale = 1
        'HeightScale = 1
        'MousePointer = OriginPoint
    End Sub
    Private Sub AppLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Initial()
        MapLoad("coastline.dat") '处理地图文件
    End Sub
    Private Sub MapLoad(Map As String)
        Dim MapSrc As New IO.StreamReader(Map)
        Dim ThisContinent As New List(Of PointF) '记录单个大洲
        Dim ThisPoint As New PointF '记录单个点
        Dim OneLineInMapFile As String() '临时用于存放一个点
        Do Until MapSrc.EndOfStream() '直到MapSrc文件指针读到文件末尾
            Dim i = MapSrc.ReadLine() 'i是字符串，文件中的一行
            If i = "# -b" Or i = "" Then '如果读到一洲的末尾
                If Not ThisContinent.Count().Equals(0) Then '如果这个洲不是空的（这个洲存在）
                    ContinentList.Add(ThisContinent.ToArray()) '把这个洲附在记录所有点的List后面
                    ThisContinent = New List(Of PointF) '将ThisContinent置成一个新List
                End If
            Else '如果没读到一个洲的末尾
                OneLineInMapFile = Split(i, vbTab) '用这个OneLineInMapFile记录一下这个点的横纵坐标
                '比例系数将经纬度翻译成像素
                ThisPoint.X = OneLineInMapFile(0) * RealToPixel
                ThisPoint.Y = -OneLineInMapFile(1) * RealToPixel
                ThisContinent.Add(ThisPoint)
            End If
        Loop
        DrawMap(NowScale, OriginPoint, ZeroMoveVector) '根据NowScale以原点为中心画图，此时NowScale为初始值
    End Sub
    Private Sub DrawMap(scale As Double, ZoomVector As PointF, MoveVector As PointF)
        Dim BMP As New Drawing.Bitmap(PictureBox.Width, PictureBox.Height)
        Dim GFX As Graphics = Graphics.FromImage(BMP)
        GFX.TranslateTransform(0, 0)
        GFX.FillRectangle(Brushes.White, 0, 0, PictureBox.Width, PictureBox.Height) '背景颜色填充
        GFX.TranslateTransform(OriginPoint.X, OriginPoint.Y) '将图坐标原点设置为图框中心
        Dim ThePen As New Pen(Color.Black, 0.1) '设定画笔数据
        ChangeOP(scale, ZoomVector, MoveVector) '映射函数
        For Each TempPoint In ContinentList
            GFX.DrawLines(ThePen, TempPoint)
        Next
        If DisKey = True Then
            ThePen = New Pen(Color.Red, 3)
            If PointNum = 1 Then
                GFX.DrawEllipse(ThePen, DStartPoint.X, DStartPoint.Y, 1, 1)
            ElseIf PointNum = 2 Then
                GFX.DrawEllipse(ThePen, DEndPoint.X, DEndPoint.Y, 1, 1)
                GFX.DrawLine(ThePen, DStartPoint, DEndPoint)
            End If
        End If
        PictureBox.Image = BMP
    End Sub
    Private Sub ChangeOP(scale As Double, ZoomVector As PointF, MoveVector As PointF)
        NowOP.X = （scale / OldScale) * （0 - (ZoomVector.X - OriginPoint.X)) + MoveVector.X + (ZoomVector.X - OriginPoint.X)
        NowOP.Y = （scale / OldScale) * （0 - (ZoomVector.Y - OriginPoint.Y)) + MoveVector.Y + (ZoomVector.Y - OriginPoint.Y)
        'NowOP指初始中心点目前所在的像素点位
        For Each TempPoint In ContinentList
            Dim i As Integer = 0
            For Each temp In TempPoint
                '以vector为中心的放缩函数
                '之前的点都是以0 0经纬度点为中心的
                '现在更改为以vector经逆映射确定的点为中心
                TempPoint(i).X = （scale / OldScale) * （TempPoint(i).X - (ZoomVector.X - OriginPoint.X)) + MoveVector.X + (ZoomVector.X - OriginPoint.X)
                TempPoint(i).Y = （scale / OldScale) * （TempPoint(i).Y - (ZoomVector.Y - OriginPoint.Y)) + MoveVector.Y + (ZoomVector.Y - OriginPoint.Y)
                'TempPoint(i).X = （scale / OldScale) * TempPoint(i).X + (ZoomVector.X - OriginPoint.X) * (1.0 / (scale / OldScale) - 1) + MoveVector.X
                'TempPoint(i).Y = （scale / OldScale) * TempPoint(i).Y + (ZoomVector.Y - OriginPoint.Y) * (1.0 / (scale / OldScale) - 1) + MoveVector.Y
                i += 1
            Next
        Next
        'NewOriginalPoint = MousePointer - OriginPoint
        'LLScale = scale / OldScale
        OldScale = scale
    End Sub

    Function Longitude(NowMousePoint As PointF) As Double
        Return ((NowMousePoint.X - OriginPoint.X - NowOP.X) / NowScale) / RealToPixel
    End Function

    Function Latitude(NowMousePoint As PointF) As Double
        Return -((NowMousePoint.Y - OriginPoint.Y - NowOP.Y) / RealToPixel) / NowScale
    End Function

    Private Sub Up_Click(sender As Object, e As EventArgs) Handles Up.Click
        Dim shift As Point
        shift.Y = +30
        DrawMap(NowScale, OriginPoint, shift)
    End Sub

    Private Sub Down_Click(sender As Object, e As EventArgs) Handles Down.Click
        Dim shift As Point
        shift.Y = -30
        DrawMap(NowScale, OriginPoint, shift)
    End Sub

    Private Sub Left_Click(sender As Object, e As EventArgs) Handles Left.Click
        Dim shift As Point
        shift.X = +30
        DrawMap(NowScale, OriginPoint, shift)
    End Sub

    Private Sub Right_Click(sender As Object, e As EventArgs) Handles Right.Click
        Dim shift As Point
        shift.X = -30
        DrawMap(NowScale, OriginPoint, shift)
    End Sub

    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        ContinentList.Clear()
        Label_ContextLongitude.Text = "请将鼠标悬浮于显示框中以查看经度"
        Label_ContextLatitude.Text = "请将鼠标悬浮于显示框中以查看纬度"
        AppLoad(sender, e)
    End Sub

    Private Sub ZoomIn_Click(sender As Object, e As EventArgs) Handles ZoomIn.Click
        NowScale = NowScale * ZoomMultiple
        DrawMap(NowScale, OriginPoint, ZeroMoveVector)
    End Sub

    Private Sub ZoomOut_Click(sender As Object, e As EventArgs) Handles ZoomOut.Click
        NowScale /= ZoomMultiple
        If NowScale <= MinScale Then
            NowScale = MinScale
            ZoomOrNot = False
        End If
        DrawMap(NowScale, OriginPoint, ZeroMoveVector)
    End Sub
    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseMove
        MousePointer.X = e.X
        MousePointer.Y = e.Y
        'NameLatitude.Enabled = True
        If ZoomOrNot = False Then
            If Longitude(MousePointer) > 0 Then
                Label_ContextLongitude.Text = "东经" + FormatNumber(Longitude(MousePointer), 2) + "°"
            ElseIf Longitude(MousePointer) < 0 Then
                Label_ContextLongitude.Text = "西经" + FormatNumber(-Longitude(MousePointer), 2) + "°"
            Else
                Label_ContextLongitude.Text = FormatNumber(Longitude(MousePointer), 2) + "°"
            End If
            If Latitude(MousePointer) > 0 Then
                Label_ContextLatitude.Text = "北纬" + FormatNumber(Latitude(MousePointer), 2) + "°"
            ElseIf Latitude(MousePointer) < 0 Then
                Label_ContextLatitude.Text = "南纬" + FormatNumber(-Latitude(MousePointer), 2) + "°"
            Else
                Label_ContextLatitude.Text = FormatNumber(Latitude(MousePointer), 2) + "°"
            End If
        End If
    End Sub

    Private Sub Scroll_map(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseWheel
        If e.Delta > 0 Then
            NowScale /= ZoomMultiple
            If NowScale <= MinScale Then
                NowScale = MinScale
                ZoomOrNot = False
            End If
            DrawMap(NowScale, MousePointer, ZeroMoveVector)
        ElseIf e.Delta < 0 Then
            NowScale *= ZoomMultiple
            DrawMap(NowScale, MousePointer, ZeroMoveVector)
        End If
    End Sub
    Private Sub Move_map_begin(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseDown
        MousePointer.X = e.X
        MousePointer.Y = e.Y
        Position = MousePointer
    End Sub
    Private Sub Move_map_end(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseUp
        Dim vector As PointF
        MousePointer.X = e.X
        MousePointer.Y = e.Y
        vector.X = MousePointer.X - Position.X
        vector.Y = MousePointer.Y - Position.Y
        DrawMap(NowScale, OriginPoint, vector)
    End Sub
    Private Sub Form1_Up(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim vec As Point
        If e.KeyData = (Keys.W) Then
            vec.Y = +30
            DrawMap(NowScale, OriginPoint, vec)
        End If
    End Sub
    Private Sub Form1_Down(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim vec As Point
        If e.KeyData = (Keys.S) Then
            vec.Y = -30
            DrawMap(NowScale, OriginPoint, vec)
        End If
    End Sub
    Private Sub Form1_Left(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim vec As Point
        If e.KeyData = (Keys.A) Then
            vec.X = +30
            DrawMap(NowScale, OriginPoint, vec)
        End If
    End Sub
    Private Sub Form1_Right(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim vec As Point
        If e.KeyData = (Keys.D) Then
            vec.X = -30
            DrawMap(NowScale, OriginPoint, vec)
        End If
    End Sub
    Private Sub Form1_Zoom_In(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = (Keys.J) Then
            NowScale = NowScale * ZoomMultiple
            DrawMap(NowScale, OriginPoint, ZeroMoveVector)
        End If
    End Sub
    Private Sub Form1_Zoom_Out(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = (Keys.K) Then
            NowScale /= ZoomMultiple
            If NowScale <= MinScale Then
                NowScale = MinScale
                ZoomOrNot = False
            End If
            DrawMap(NowScale, OriginPoint, ZeroMoveVector)
        End If
    End Sub
End Class


