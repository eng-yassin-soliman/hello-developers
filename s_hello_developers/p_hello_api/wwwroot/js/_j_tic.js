class _c_tic_ : _j_game
{
    constructor(p_pnl_, p_ycr_, p_xcr_) { }

}

class _c_cell {
    constructor(p_pnl_, p_ycr_, p_xcr_) {
        this.s_xcr_ = p_xcr_;
        this.s_ycr_ = p_ycr_;

        this.s_pnl_ = p_pnl_;
        this.s_rec_ = document.createElementNS('http://www.w3.org/2000/svg', 'rect');
        this.s_pnl_.appendChild(this.s_rec_);

        var l_pos_ = this.f_position_();
        this.s_rec_.setAttribute("x", l_pos_.s_xcr_);
        this.s_rec_.setAttribute("y", l_pos_.s_ycr_);
        this.s_rec_.setAttribute("width", "130");
        this.s_rec_.setAttribute("height", "130");
        this.s_rec_.setAttribute("fill", "transparent");

        this.s_rec_.onclick = this.v_click_.bind(this);

        this.s_txt_ = document.createElementNS('http://www.w3.org/2000/svg', 'text');
        this.s_pnl_.appendChild(this.s_txt_);

        this.s_txt_.setAttribute("x", l_pos_.s_xcr_ + 80);
        this.s_txt_.setAttribute("y", l_pos_.s_ycr_ + 85);
        this.s_txt_.setAttribute("font-size", 80);
        this.s_txt_.setAttribute("style", "fill: black");
        this.s_txt_.setAttribute("font-family", "Indie Flower");
    }

    f_position_() {
        var l_xcr_ = (this.s_xcr_ * 130) + ((this.s_xcr_ + 1) * 27.5);
        var l_ycr_ = (this.s_ycr_ * 130) + ((this.s_ycr_ + 1) * 27.5);

        return { s_xcr_: l_xcr_, s_ycr_: l_ycr_ }
    }

    v_click_(p_arg_) { v_send_(this); }
}