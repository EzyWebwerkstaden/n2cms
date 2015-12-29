<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%@ Import Namespace="N2.Web.Rendering" %>
<%@ Import Namespace="N2.Web.Mvc.Html" %>
<%
    
	var name = Model ?? Html.DisplayableToken().GenerateInputName();
    var isRequired = name.Contains("|required");
    if (isRequired)
        name = name.Replace("|required", "");
%>
<span class="formfield forminput">
<input type="email" name="<%= name %>" <%=isRequired ? "required" : "" %> class="form-control" />
</span>
