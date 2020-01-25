dofile 'LuaScripts\\test1\\sph.lua';

local map = World:CreateMap();
map.Physic = Logic:CreatePhysic();

local Sph = CreateSphere();
map:AddObject(Sph);

local camera = Render:NewCamera();
camera.Map = map;
camera.BackColor = Color(255,0,0,0);
camera.ViewPort = Viewport(
	0, --X
	0, --Y
	Window.iWidth, --Width
	Window.iHeight, --Height
	0, --MinZ
	1 --MaxZ
);

---------------------
--Системные События--
---------------------

_keys = {};

--Обработчие события при движении мыши
Window.OnMouseMove = function(x, y, keys)
    local camx = (y / Window.iHeight - 0.5) * math.pi;
    local caym = (-x / Window.iWidth - 0.5) * math.pi*2;
	camera.angle = Vector(camx, caym, 0);
end;

--Обработчие события при нажатии кнопки
Window.OnKeyDown = function(key)
	_keys[key] = true;
	
	if key == 27 then
		Window:Close();
	else
		print(key);
	end; 
end;

Window.OnKeyUp = function(key)
	_keys[key] = false;
end;

--------------
--Смена фона--
--------------

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
  camera.BackColor = Color(255,
    _wc11[1]*(1-_wt) + _wc12[1]*_wt,
    _wc11[2]*(1-_wt) + _wc12[2]*_wt,
    _wc11[3]*(1-_wt) + _wc12[3]*_wt
  );
  _wt = _wt + 0.02;
end;