<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="comp2007_lesson10_wed1._404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="has-error">
        <h2><asp:Label ID="lblError" runat="server">The page or Directory you're trying to access is temporary unavailable, Please allow us to maintain it.</asp:Label></h2>
    </div>
</asp:Content>
