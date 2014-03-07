<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
     多企业用户管理系统|联系我们
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-content">
        <!--============================== content begin=================================-->
        <div id="content">
            <div class="ic">More Website Templates at <a href="http://www.cssmoban.com/">Website Template</a></div>
            <div class="container">
                <div class="row">
                    <article class="span8">
                        <h3>Contact us</h3>
                        <div class="inner-1">
                            <form id="contact-form">
                                <div class="success">Contact form submitted! <strong>We will be in touch soon.</strong> </div>
                                <fieldset>
                                    <div>
                                        <label class="name">
                                            <input type="text" value="Your name">
                                            <br>
                                            <span class="error">*This is not a valid name.</span> <span class="empty">*This field is required.</span>
                                        </label>
                                    </div>
                                    <div>
                                        <label class="phone">
                                            <input type="tel" value="Telephone">
                                            <br>
                                            <span class="error">*This is not a valid phone number.</span> <span class="empty">*This field is required.</span>
                                        </label>
                                    </div>
                                    <div>
                                        <label class="email">
                                            <input type="email" value="Email">
                                            <br>
                                            <span class="error">*This is not a valid email address.</span> <span class="empty">*This field is required.</span>
                                        </label>
                                    </div>
                                    <div>
                                        <label class="message">
                                            <textarea>Message</textarea>
                                            <br>
                                            <span class="error">*The message is too short.</span> <span class="empty">*This field is required.</span>
                                        </label>
                                    </div>
                                    <div class="buttons-wrapper"><a class="btn btn-1" data-type="reset">Clear</a> <a class="btn btn-1" data-type="submit">Send</a></div>
                                </fieldset>
                            </form>
                        </div>
                    </article>
                    <article class="span4">
                        <h3>Contact info</h3>
                        <div class="map">
                            <iframe src="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Brooklyn,+New+York,+NY,+United+States&amp;aq=0&amp;sll=37.0625,-95.677068&amp;sspn=61.282355,146.513672&amp;ie=UTF8&amp;hq=&amp;hnear=Brooklyn,+Kings,+New+York&amp;ll=40.649974,-73.950005&amp;spn=0.01628,0.025663&amp;z=14&amp;iwloc=A&amp;output=embed"></iframe>
                        </div>
                        <address class="address-1">
                            <strong>Grewis<br>
                                8901 Marmora Road<br>
                                Glasgow, D04 89GR.</strong>
                            <div class="overflow">
                                <span>Freephone:</span>+1 800 559 6580<br>
                                <span>Telephone:</span>+1 800 603 6035<br>
                                <span>FAX:</span>+1 800 889 9898
                                <br>
                                <span>E-mail:</span> <a href="#" class="mail-1">mail@demolink.org</a><br>
                                <span>Skype:</span> <a href="#" class="mail-1">@skypename</a>
                            </div>
                        </address>
                    </article>
                </div>
            </div>
        </div>
        <!--============================== content end=================================-->
    </div>

</asp:Content>
