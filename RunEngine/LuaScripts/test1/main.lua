dofile 'LuaScripts\\test1\\sph.lua';

local map = Map();
local Sph = CreateSphere();
map:AddObject(Sph);

local Camera = Camera3D();
Camera.BackColor = Color(255,0,0,0);

local _wt = 0;
local _wt2 = 0;
local _wc11 = {0,0,0};
local _wc12 = {0,0,0};

OnTimer = function()
  if _wt >= 1 then
    _wt = 0;
    _wc11 = _wc12;
    _wc12 = {math.random(256)-1, math.random(256)-1, math.random(256)-1}
  end;
  Camera.BackColor = Color(255,
    _wc11[1]*(1-_wt) + _wc12[1]*_wt,
    _wc11[2]*(1-_wt) + _wc12[2]*_wt,
    _wc11[3]*(1-_wt) + _wc12[3]*_wt
  );
  _wt = _wt + 0.02;
end;