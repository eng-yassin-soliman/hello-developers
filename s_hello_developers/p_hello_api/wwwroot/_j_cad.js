// A JavaScript method to make http requests
// p_scc_: A function to call on success
// p_err_: A function to call on error
function v_post_(p_msg_, p_scc_, p_err_)
{
    fetch(
        'hello/api',        // URL to post to
        {   // Array of HTTP request headers
            headers: { "Content-Type": "text/plain; charset=utf-8" },
            method: 'POST', // HTTP verp: POST, GET, etc..
            body: p_msg_,   // HTTP request body
        })
        .then(function (p_rsp_) { return p_rsp_.text(); })
        .then(function (p_txt_) { p_scc_(p_txt_); })
        .catch(function (p_rsp_) { p_err_(p_rsp_); });
}