function v_post_(p_url_, p_msg_, p_typ_, p_scc_, p_err_)
{
    fetch(
        p_url_,
        {
            headers: { "Content-Type" : p_typ_ },
            method: 'POST',
            body: p_msg_,
        })
        .then(function (p_rsp_) { return p_rsp_.text(); })
        .then(function (p_txt_) { p_scc_(p_txt_); })
        .catch(function (p_rsp_) { p_err_(p_rsp_); });
}

function v_post_txt_(p_url_, p_msg_, p_scc_, p_err_)
{
    v_post_(p_url_, p_msg_, "text/plain; charset=UTF-8", p_scc_, p_err_)
}

function v_post_obj_(p_url_, p_msg_, p_scc_, p_err_)
{
    var l_msg_ = JSON.stringify(p_msg_);

    v_post_(p_url_, l_msg_, "application/json; charset=UTF-8", p_scc_, p_err_)
}