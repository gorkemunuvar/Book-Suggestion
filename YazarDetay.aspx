<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YazarDetay.aspx.cs" Inherits="KitapDetay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <hr />
                <center>
                    <asp:Label ID="labelYazarDetay" runat="server" Text="Yazar Detay"></asp:Label>
               </center>
                <hr />
            </div>
            <div>
                <table border="0" cellpadding="0">

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="lableAdSoyad"><b>Soyadi:</b> Hawking</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelDogumYeri"><b>Doğum Yeri:</b> İngiltere/Londra</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelDogumTarihi"><b>Doğum Tarihi:</b> 1935</asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                            <asp:Label runat="server" ID="labelOlumTarihi"><b>Ölüm Tarihi:</b> 2018</asp:Label>
                        </td>
                        <td align="left" class="auto-style8">&nbsp;&nbsp;&nbsp;
                        </td>
                    <tr>
                        <td align="center" >
                            <center>
                                <hr />
                                    Yazara Ait Kitaplar
                                    <hr />
                            </center>

                            <asp:GridView ID="gVYazaraAitKitaplar" OnSelectedIndexChanged="gVYazaraAitKitaplar_SelectedIndexChanged" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateSelectButton="True">
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

                    </tr>

                </table>
            </div>
        </div>
    </form>
</body>
</html>
