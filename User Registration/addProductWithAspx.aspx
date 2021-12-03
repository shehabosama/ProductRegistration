<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addProductWithAspx.aspx.cs" Inherits="User_Registration.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="styles.css" />

</head>
<body>
     <div class="center"><h1>Add Product</h1></div> 
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hfUserID" runat="server" />
    <table>
        <tr>
            <td>
                <h2>Name Of Product: </h2>
            </td>
            <td colspan="2">
                <asp:TextBox ID="nameOfProduct" runat="server" Width="399px" />
                 <asp:Label Text="*" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td>
              <h2>NumberOf Product: </h2>
            </td>
            <td colspan="2">
                <asp:TextBox ID="numberOfProduct" runat="server" Width="399px" />
                 <asp:Label Text="*" runat="server" ForeColor="Red" />
            </td>
        </tr>
       
        <tr>
            <td>
              <h2>Country Of Manufacture: </h2>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="countryOfProduct" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
             <h2>Manufacturing Year: </h2>
            </td>
            <td colspan="2">
             
                 
                 
                <asp:TextBox ID="yearOfManufacturing" runat="server" Width="399px" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
              <h2>Price Of Product: </h2>
            </td>
            <td colspan="2">
                <asp:TextBox ID="priceOfProduct" runat="server" Width="399px"/>
               
            </td>
        </tr>
        <tr>
            <td>
                <h2>Type Of Product: </h2>
            </td>
            <td colspan="2">
                <asp:TextBox ID="typeOfProdcut" runat="server" Width="399px" />
                
            </td>
        </tr>
      
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Button Text="Submit" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green" /> </h2>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red" /> </h2>
            </td>
        </tr>

    </table>
    </div>
    </form>
</body>
</html>
