dofile 'LuaScripts\\test2\\sph.lua';

local map = Map();
local Sph = CreateSphere(map,30,30);
map:AddObject(Sph);

local Camera = Camera3D();
Camera.BackColor = Color(255,51,51,51);