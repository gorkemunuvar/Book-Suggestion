<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KullaniciProfili.aspx.cs" Inherits="KitapDetay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 243px;
            height: 107px;
            margin-top: 0px;
        }

        .auto-style2 {
            width: 229px;
        }

        .auto-style3 {
            width: 287px;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <hr />
                <center>
                    <asp:Label ID="labelKullaniciProfili" runat="server" Text="Kullanıcı Profili"></asp:Label>
               </center>
                <hr />
            </div>
            <div>
                <table border="0" cellpadding="1">
                    <tr>
                        <td rowspan="6" class="auto-style6">
                            <center>
                                <asp:Image ID="imgKullanici" runat="server" Height="169px" Width="158px" />
                                 <br />
                             </center>
                        </td>

                        <td align="left" class="auto-style3">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelAdi"><b>Adı:</b> Ali</asp:Label>
                        </td>


                        <td rowspan="6" valign="top" class="auto-style2">
                            <hr />
                            <center>
                            <asp:Label runat="server" ID="labelGonderilecekMesaj"><b>Gönderilecek Mesaj</b></asp:Label>
                            </center>
                            <hr />
                            <asp:Label ID="Label1" runat="server" Text="Başlık:   "></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtBaslik" runat="server" Width="153px"></asp:TextBox>
                            <hr />
                            <textarea id="txtAreaMesaj" runat="server" class="auto-style1" name="S1"></textarea>
                            <br />
                            <asp:Button ID="btnMesajGonder"  OnClick="btnMesajGonder_Click" Text="Mesaj Gönder" runat="server" />
                            <asp:Label ID="labelSonuc" runat="server" ForeColor="Black"></asp:Label>
                            <hr />
                        </td>




                    </tr>

                    <tr>
                        <td align="left" class="auto-style3">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelSoyadi"><b>Soyadi:</b> Görkem</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style3">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelKullaniciAdi"><b>Kullanıcı Adı:</b> a.gorkem</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style3">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labellDogumTarihi"><b>Doğum Tarihi:</b> 1997</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style3">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelCinsiyet"><b>Cinsiyet:</b> Erkek</asp:Label>

                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style3">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelMail"><b>Mail:</b> a.gorkemunuvar@gmail.com</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" align="center" valign="top">
                            <center>
                                <hr />
                                    Okuduğu Kitaplar
                                    <hr />
                            </center>
                            <asp:GridView ID="gVKitaplar" Width="450" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                            <center>
                                <hr />
                                    Verdiği Puanlar
                                <hr />
                            </center>
                            <asp:GridView ID="gVVerdigiPuanlar" Width="450" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                        </td>

                        <td align="center" colspan="1">
                            <center>
                                <hr />
                                    İnceleme Ve Yorumları
                                <hr />
                            <asp:GridView ID="gVIncelemeVeYorumlari" Width="650" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                </asp:GridView>
                            <center>
                                <hr />
                                    Yaptığı Alıntılar
                                <hr />
                            </center>
                            <asp:GridView ID="gVYaptigiAlintilar" Width="650" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                </asp:GridView>
                            </center>

                        </td>

                    </tr>

                </table>
            </div>
        </div>
       
    </form>
</body>
</html>
