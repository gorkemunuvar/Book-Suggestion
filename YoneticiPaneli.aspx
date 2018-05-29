<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YoneticiPaneli.aspx.cs" Inherits="KayitOl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        #container {
            width: 1500px;
            height: 1500px;
            position: absolute;
            left: 15%;
            top: 27%;
            margin-left: -50px;
            margin-top: -50px;
        }

        .auto-style3 {
            left: 4%;
            top: 15%;
            width: 974px;
            height: 407px;
        }

        .auto-style5 {
            height: 24px;
        }

        .auto-style6 {
            width: 236px;
            height: 45px;
        }
    </style>
    <title></title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#dttpTarih").datepicker({
                showOn: "button",
                buttonImage: "takvim.png",
                buttonImageOnly: true,
                dateFormat: "dd.mm.yy",
                monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
                dayNamesMin: ["Pts", "Sl", "Çrş", "Prş", "Cm", "Cts", "Pzr"]
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <hr />
            <center>
                    <asp:Label ID="Label1" runat="server" Text="Yönetici Paneli"></asp:Label>
               </center>
            <hr />
        </div>
        <div id="container" class="auto-style3">

            <div>
                <table cellpadding="0" border="0">
                    <tr>
                        <td align="center" colspan="1">
                            <hr />
                            Kitap Kaydet
                            <hr />
                        </td>

                         <td rowspan="8" valign="top" align="center">
                             <hr />
                             <asp:Label ID="lblKayitliKitaplar" runat="server">Kayıtlı Kitaplar</asp:Label>
                             <hr />

                            <div id="popup" style="max-height: 221px; max-width: 700px;  overflow-y: scroll; overflow-x: scroll; ">
                                <asp:GridView ID="gVKayitliKitaplar" runat="server" OnSelectedIndexChanged="gVKayitliKitaplar_SelectedIndexChanged" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" >
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
                            </div>
                            
                        </td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblKitapAdi" runat="server">Kitap Adı: </asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                            <asp:TextBox ID="txtKitapAdi" runat="server" Width="203px" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblYazari" runat="server">Yazarı: </asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="dropDownYazarlar" runat="server" Height="18px" Width="208px">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblYayinEvi" runat="server">Yayın Evi: </asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             &nbsp;&nbsp; &nbsp;
                             <asp:TextBox ID="txtYayinEvi" runat="server" Width="202px" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblFotoYukle" runat="server">Fotoğraf Yükle: </asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:FileUpload ID="fileUploadFotoYukle" runat="server" Width="174px" />
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblTanitimi" runat="server">Tanıtımı: </asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;

                             <textarea id="txtTanitimBilgisi" class="auto-style6" name="S1" runat="server"></textarea>
                    </tr>

                    <tr>
                        <td align="center" class="auto-style5">
                            <asp:Label ID="lblDurum" runat="server" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblSonuc" runat="server" ForeColor="Red"></asp:Label>

                        </td>
                    </tr>

                    <tr>
                        <td align="right">
                            <hr />
                            <asp:Button ID="btnKaydet" Text="Kaydet" OnClick="btnKaydet_Click" runat="server" />
                            <asp:Button ID="btnGuncelle" Text="Güncelle" OnClick="btnGuncelle_Click" runat="server" />
                            <asp:Button ID="btnSil" Text="Sil" OnClick="btnSil_Click" runat="server" />
                            <hr>
                        </td>
                    </tr>

                </table>
            </div>

        </div>
    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>
