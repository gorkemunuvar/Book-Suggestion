<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profilim.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kitap Değerlendirme Ve Tavisye Sistemi</title>
    <meta charset="UTF-8" />
    <link rel="StyleSheet" type="text/css" href="StyleSheet.css" />
    <style type="text/css">
        #iskelet {
            height: 594px;
        }

        #div3 {
            height: 526px;
        }
    </style>
</head>
<body style="height: 601px">
    <form id="form1" runat="server">
        <div class="ana_div" id="iskelet">
            <div class="div1" id="div1">
                <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" StaticSubMenuIndent="10px" Height="163px" Width="85px">
                    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#F7F6F3" />
                    <DynamicSelectedStyle BackColor="#5D7B9D" />
                    <Items>
                        <asp:MenuItem Text="Tavsiyeler" Value="Tavsiyeler" NavigateUrl="~/Tavsiyeler.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Kitaplar" Value="Kitaplar" NavigateUrl="~/Kitaplar.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Yazarlar" Value="Yazarlar" NavigateUrl="~/Yazarlar.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Kullanıcılar" Value="Kullanıcılar" NavigateUrl="~/Kullanicilar.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Profilim" Value="Profilim" NavigateUrl="~/Profilim.aspx" Selected="True"></asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#5D7B9D" />
                </asp:Menu>
            </div>

            <div class="div" id="div2">
                <hr />
                <center>
                    <asp:Label ID="Label1" runat="server" Text="Profilim"></asp:Label>
               </center>
                <hr />
            </div>
            <div class="div" id="div3">
                <table border="0" cellpadding="1">
                    <tr>
                        <td rowspan="6" class="auto-style6">
                            <center>
                                <asp:Image ID="imgKullanici" runat="server" Height="208px" Width="177px" ImageUrl="~/Resimler/profil.png" />
                                 <br />
                             </center>
                        </td>

                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelAdi"><b>Adı:</b> Ali</asp:Label>
                        </td>

                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelSoyadi"><b>Soyadi:</b> Görkem</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelKullaniciAdi"><b>Kullanıcı Adı:</b> a.gorkem</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labellDogumTarihi"><b>Doğum Tarihi:</b> 1997</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelCinsiyet"><b>Cinsiyet:</b> Erkek</asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelMail"><b>Mail:</b> a.gorkemunuvar@gmail.com</asp:Label>
                        </td>
                    </tr>

                    </tr>
                </table>

                <table>
                        <hr />
                <center>
                                    Mesajlarım
                                </center>
                <hr />
                <asp:GridView ID="gVGelenMesajlar" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnSelectedIndexChanged="gVGelenMesajlar_SelectedIndexChanged">
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                </table>

            </div>

        </div>
    </form>
</body>
</html>
