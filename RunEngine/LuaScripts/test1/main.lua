dofile 'LuaScripts\\test1\\sph.lua';
dofile 'LuaScripts\\test1\\randomColor.lua';

Window = WindowWinAPI(windowName, windowName);
Render = DirectX(Window);
Physic = PhysX();

local map = World:CreateMap();

local Sph = CreateSphere();

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
local backColor = RandomColor(1);
Window:CreateTimer(12,
	function(uElapse)
		camera.BackColor = backColor:GetColor(uElapse);
	end
);

---------------------
--Системные События--
---------------------

_keys = {};

--Обработчие события при движении мыши
Window.OnMouseMove = function(x, y, keys)
	local camx = (x / Window.iWidth - 0.5) * math.pi*2;
    local camy = (y / Window.iHeight - 0.5)*0.999 * math.pi;
	camera.angle = Vector(camx, camy, 0);
	camera.pos = Vector(-3*math.sin(camx)*math.cos(camy), 3*math.sin(camy), -3*math.cos(camx)*math.cos(camy));
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

Window:CreateTimer(12,
	function(uElapse)
		Physic:Update(uElapse/1000);
		Render:OnPaint();
	end
);

if NotWindowRun then
	return;
end;

Window:Run();