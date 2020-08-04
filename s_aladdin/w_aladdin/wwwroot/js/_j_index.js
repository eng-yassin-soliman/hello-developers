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