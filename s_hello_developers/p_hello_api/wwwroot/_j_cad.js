function v_post_(p_msg_, p_scc_, p_err_) {
    fetch('hello/api',        // URL to post to        
        {   // Array of HTTP request headers            
            headers: { "Content-Type": "text/plain; charset=utf-8" },
            method: 'POST', // HTTP verp: POST, GET, etc..            
            body: p_msg_,   // HTTP request body        
        })
        .then(function (p_rsp_) {
            return p_rsp_.text();
        })
        .then(function (p_txt_) {
            p_scc_(p_txt_);
        })
        .catch(function (p_rsp_) {
            p_err_(p_rsp_);
        });
}
// Post the message to server

function v_send_() {
    var l_req_ = document.getElementById('b_req_').value;
    v_post_(l_req_, v_success_, v_error_);
}
// Handle the response is succeededfunction 
function v_success_(p_rsp_)
{
    document.getElementById('b_rsp_').value = p_rsp_;
}
// Handle the response on errorfunction v_error_(p_rsp_)         
function v_error_(){
    alert('Error');
}