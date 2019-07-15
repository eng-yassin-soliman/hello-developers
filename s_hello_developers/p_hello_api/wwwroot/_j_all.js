function v_post_text_(p_msg_) {
    fetch('hello/api',
        {
            headers: { "Content-Type": "text/plain; charset=utf-8" },
            method: 'POST',
            body: p_msg_,
        }).then(p_rsp_ => f_response_(p_rsp_));
}

function v_post_json_(p_msg_)
{
    fetch('hello/api',
        {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'POST',
            body: JSON.stringify(p_msg_),
        }).then(p_rsp_ => f_response_(p_rsp_));
}

function f_response_(p_rsp_)
{
    p_rsp_.text().then(
        function (p_txt_)
        {
            alert(p_txt_);
        });
}