function RandomColor(time)
	return {
		t = 0;
		c1 = {0,0,0};
		c2 = {0,0,0};

		GetColor = function(this, uElapse)
			this.t = this.t + uElapse/1000;
			if this.t >= time then
				this.t = 0;
				this.c1 = this.c2;
				this.c2 = {math.random(256)-1, math.random(256)-1, math.random(256)-1}
			end;
			return Color(255,
				this.c1[1]*(1-this.t) + this.c2[1]*this.t,
				this.c1[2]*(1-this.t) + this.c2[2]*this.t,
				this.c1[3]*(1-this.t) + this.c2[3]*this.t
			);
		end;
	};
end;