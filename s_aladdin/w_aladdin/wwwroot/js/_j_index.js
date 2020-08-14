$(document).ready(function ()
{ f_loaded_(); });

function f_loaded_()
{
    f_resize_();
    $("#b_img_").css("visibility", "visible");
}

function f_resize_()
{
    var l_wdt_ = $(window).width();                             // window width
    var l_hgt_ = $(window).height() -
        $("#b_nav_").height() - $("#b_fot_").height();          // window height

    if (l_wdt_ > l_hgt_)
    {
        $("#b_img_").css({ "width": ""});
        $("#b_img_").css("height", (l_hgt_ * 0.6) + "px");
        $("#b_img_").css("margin-top", (l_hgt_ * 0.2) + "px");
    }
    else
    {
        $("#b_img_").css({ "height": "" });
        $("#b_img_").css("width", (l_wdt_ * 0.5) + "px");
    }
}

// Post the message to server
function v_send_(p_url_)
{
    // var l_req_ = document.getElementById('b_req_').value;

    var l_req_ =
    {
        "s_1st_": 17,
        "s_2nd_": 19
    };

    v_post_obj_(p_url_, l_req_, v_success_, v_error_);
}

// Handle the response is succeeded
function v_success_(p_rsp_)
{
    document.getElementById('b_rsp_').value = p_rsp_;
}

// Handle the response on error
function v_error_(p_rsp_)
{
    alert("Error: " + p_rsp_);
}