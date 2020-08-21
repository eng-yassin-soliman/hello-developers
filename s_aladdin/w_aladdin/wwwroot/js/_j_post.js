function v_post_(p_url_, p_msg_, p_typ_, p_scc_, p_err_)
{
    $.ajax(
        {
            method: "POST",
            contentType: p_typ_,
            url: p_url_,
            data: p_msg_,
            success: p_scc_,
            error: p_err_
        });
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