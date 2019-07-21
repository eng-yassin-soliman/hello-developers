// A JavaScript method to make http requests
// p_scc_: A function to call on success
// p_err_: A function to call on error
function v_post_(p_url_, p_msg_, p_typ_, p_scc_, p_err_)
{
    fetch(
        'CAD/api',          // URL to post to
        {   // Array of HTTP request headers
            headers: { "Content-Type" : p_typ_ },
            method: 'POST', // HTTP verb: POST, GET, etc..
            body: p_msg_,   // HTTP request body
        })
        .then(function (p_rsp_) { return p_rsp_.text(); })
        .then(function (p_txt_) { p_scc_(p_txt_); })
        .catch(function (p_rsp_) { p_err_(p_rsp_); });
}

function v_post_txt_(p_url_, p_msg_, p_scc_, p_err_)
{
    v_post_(p_url_, p_msg_, "text/plain; charset=UTF-8", p_scc_, p_err_)
}

// Convert objects (instances of classes) to string (encoded by JSON format)
// Then post them as text
function v_post_obj_(p_url_, p_msg_, p_scc_, p_err_)
{
    var l_msg_ = JSON.stringify(p_msg_);
    v_post_(p_url_, l_msg_, "application/json; charset=UTF-8", p_scc_, p_err_)
}