class _c_tic_ {
    constructor() {
        // User and game info to be exchanged between client and server
        this.s_usr_ = {
            get s_nam_() { return document.getElementById("b_nam_").value; },   // Name
            get s_pas_() { return document.getElementById("b_pas_").value; },   // Password
            s_ssn_: Math.random().toString(),                                   // Session ID
            s_sgn_: '',                                                         // Symbol (A&#$%)
            s_clk_: 0,                                                          // Clicked box
            s_win_: 0,                                                          // Won gams
            s_los_: 0,                                                          // Lost games
            s_brd_: null,                                                       // Game board cells
        };

        // Initialized?
        this.s_int_ = false;

        // All boxes
        this.s_cel_ = [];
    }

    // Get drawing panel
    f_panel_() { return document.getElementById("b_pnl_"); }

    // Prepare the game for the first time
    v_intit_() {
        var l_tic_ = this;

        if (l_tic_.s_int_)
        {
            this.v_click_(null);
            return;
        }

        var l_pts_ = [
            [[170.75, 37.5], [170.75, 462.5]],
            [[328.25, 37.5], [328.25, 462.5]],
            [[37.5, 170.75], [462.5, 170.75]],
            [[37.5, 328.25], [462.5, 328.25]]];

        l_pts_.forEach(function (p_itm_, p_ndx_) {
            var l_lin_ = document.createElementNS('http://www.w3.org/2000/svg', 'line');
            l_tic_.f_panel_().appendChild(l_lin_);

            var l_pt1_ = p_itm_[0];
            var l_pt2_ = p_itm_[1];

            l_lin_.setAttribute('x1', l_pt1_[0]);
            l_lin_.setAttribute('y1', l_pt1_[1]);
            l_lin_.setAttribute('x2', l_pt2_[0]);
            l_lin_.setAttribute('y2', l_pt2_[1]);
            l_lin_.setAttribute('stroke', 'black');
            l_lin_.setAttribute('stroke-width', '6');
            l_lin_.setAttribute('stroke-linecap', 'round');
        });

        for (var i_row_ = 0; i_row_ < 3; i_row_++) {
            for (var i_col_ = 0; i_col_ < 3; i_col_++) {
                var l_cel_ = new _c_cell(l_tic_, i_row_, i_col_);
                l_tic_.s_cel_.push(l_cel_);
            }
        }

        this.v_click_(null);
        l_tic_.s_int_ = true;
    }

    v_click_(p_cel_)
    {
        if (p_cel_ == null)
        {
            // No clicked box, just loading the game for first time
            this.s_usr_.s_clk_ = 9;
        }
        else
        {
            // Set clicked index (0-8) using y, x
            this.s_usr_.s_clk_ = (p_cel_.s_row_ * 3) + p_cel_.s_col_;
        }

        v_send_(this.s_usr_);
    }

    v_response_(p_rsp_)
    {
        var l_tic_ = this;

        document.getElementById('b_lst_').innerHTML = '';

        var l_drw_ = JSON.parse(p_rsp_);
        var l_usr_; // Current user

        l_drw_.forEach(function (p_itm_, p_ndx_) {
            if (p_itm_.s_ssn_ == l_tic_.s_usr_.s_ssn_) { l_usr_ = p_itm_ }

            var l_itm_ = document.createElement('div');
            document.getElementById('b_lst_').appendChild(l_itm_);

            l_itm_.setAttribute('class', '_item');

            var l_dv1_ = document.createElement('div');
            l_dv1_.setAttribute('style', 'display:inline-block; width:310px');
            l_dv1_.innerText = p_itm_.s_nam_;
            l_itm_.appendChild(l_dv1_);

            var l_dv2_ = document.createElement('div');
            l_dv2_.setAttribute('style', 'display:inline-block; width:70px');
            l_dv2_.innerText = p_itm_.s_win_;
            l_itm_.appendChild(l_dv2_);

            var l_dv3_ = document.createElement('div');
            l_dv3_.setAttribute('style', 'display:inline-block; width:70px');
            l_dv3_.innerText = p_itm_.s_los_;
            l_itm_.appendChild(l_dv3_);
        });

        if (l_drw_.length == 1) { return; }

        for (var i_ndx_ = 0; i_ndx_ < 9; i_ndx_++)
        {
            switch (l_usr_.s_brd_[i_ndx_])
            {
                case 0:
                    document.getElementsByTagName('text')[i_ndx_].textContent = "";
                    break;

                case 1:
                    document.getElementsByTagName('text')[i_ndx_].textContent = l_usr_.s_sgn_;
                    break;

                case 2:
                    document.getElementsByTagName('text')[i_ndx_].textContent = "#";
            }

        }

        if (l_usr_.s_los_ == 10) { alert('حظ سعيد في المرة القادمة'); }
    }
}

class _c_cell {
    constructor(p_gam_, p_row__, p_col_) {
        this.s_gam_ = p_gam_;   // A reference to the containing object

        this.s_col_ = p_col_;
        this.s_row_ = p_row__;

        this.s_pnl_ = p_gam_.f_panel_();
        this.s_rec_ = document.createElementNS('http://www.w3.org/2000/svg', 'rect');
        this.s_pnl_.appendChild(this.s_rec_);

        var l_pos_ = this.f_position_();
        this.s_rec_.setAttribute("x", l_pos_.s_col_);
        this.s_rec_.setAttribute("y", l_pos_.s_row_);
        this.s_rec_.setAttribute("width", "130");
        this.s_rec_.setAttribute("height", "130");
        this.s_rec_.setAttribute("fill", "transparent");
        this.s_rec_.onclick = this.v_click_.bind(this);

        this.s_txt_ = document.createElementNS('http://www.w3.org/2000/svg', 'text');
        this.s_pnl_.appendChild(this.s_txt_);

        this.s_txt_.setAttribute("x", l_pos_.s_col_ + 80);
        this.s_txt_.setAttribute("y", l_pos_.s_row_ + 85);
        this.s_txt_.setAttribute("font-size", 80);
        this.s_txt_.setAttribute("style", "fill: black");
        this.s_txt_.setAttribute("font-family", "Indie Flower");
    }

    f_position_() {
        var l_xcr_ = (this.s_col_ * 130) + ((this.s_col_ + 1) * 27.5);
        var l_ycr_ = (this.s_row_ * 130) + ((this.s_row_ + 1) * 27.5);

        return { s_col_: l_xcr_, s_row_: l_ycr_ }
    }

    v_click_(p_arg_)
    {
        this.s_gam_.v_click_(this);
    }
}