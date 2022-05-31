<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardList.aspx.cs" Inherits="DotNetNote.DotNetNote.BoardList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align: center;">게시판</h2>
    <span style="color: #ff0000">글 목록 - 완성형 게시판입니다.</span>
    <hr />
    <table style="width: 700px; margin-left: auto; margin-right: auto;">
        <tr>
            <td>
                <style>
                    table th {
                        text-align : center;
                    }
                </style>
                <div style="font-style : italic; text-align : right; font-size : 8pt;">
                Total Record:
                    <asp:Literal ID="lblTotalRecord" runat="server"></asp:Literal>
                </div>
                <asp:GridView ID="ctlBoardList"
                    runat="server" AutoGenerateColumns="False" DataKeyNames="boardId"
                    CssClass="table table-bordered table-hover table-condensed 
                        table-striped table-responsive">
                    <Columns>
                        <asp:TemplateField HeaderText="번호"
                            HeaderStyle-Width="50px"
                            ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <%# TotalRecord - Convert.ToInt32(Eval("RowNumber").ToString()) + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="제 목"
                            ItemStyle-HorizontalAlign="Left"
                            HeaderStyle-Width="350px">
                            <ItemTemplate>
                                <%# getStepHTML(Eval("Step")) %>
                                <asp:HyperLink ID="lnkTitle" runat="server"
                                    NavigateUrl=
                                    '<%# "BoardView.aspx?boardId=" + Eval("boardId") %>'>
                                    <%# Eval("Title") %>
                                </asp:HyperLink>
                                <%# Eval("CommentCount") %>
                                <%# NewImg(Eval("PostDate"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="파일"
                            HeaderStyle-Width="70px"
                            ItemStyle-HorizontalAlign="Center" DataField="Name">
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="작성자"
                            HeaderStyle-Width="60px"
                            ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:TemplateField HeaderText="작성일"
                            ItemStyle-Width="90px"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# ShowTime(Eval("PostDate")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ReadCount" HeaderText="조회수"
                            ItemStyle-HorizontalAlign="Right"
                            HeaderStyle-Width="60px"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <a href="BoardList.aspx?page=0">1</a> | 
                <a href="BoardList.aspx?page=1">2</a> | 
                <a href="BoardList.aspx?page=2">3</a> 
            </td>
        </tr>
        <tr>
            <td style="text-align : right;">
                <a href="BoardWrite.aspx" class="btn btn-primary">글쓰기</a>
            </td>
        </tr>
    </table>
</asp:Content>
