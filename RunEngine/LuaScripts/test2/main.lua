dofile 'LuaScripts\\test2\\sph.lua';

Window = WindowWinAPI(windowName, windowName);
Render = DirectX(Window);
Physic = PhysX();

local map = World:CreateMap();

local Sph = CreateSphere(map,30,30);
map:AddObject(Sph);

Physic:CreateGroundPlane();

local cameraSpeed = 20;
local camera = Render:NewCamera();
camera.Map = map;
camera.pos = Vector(-10,0,0);
camera.BackColor = Color(255,51,51,51);
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
	local camx = (x / Window.iWidth - 0.5) * math.pi*2;
    local camy = (y / Window.iHeight - 0.5)*0.999 * math.pi;
	camera.angle = Vector(camx, camy, 0);
end;

--Обработчие события при нажатии кнопки
Window.OnKeyDown = function(key)
	_keys[key] = true;

	if key == 27 then
		Window:Close();
	elseif key == 32 then
		map:AddObject(CreateSphere(map,30,30));

		--CreateCube(math.random()*10-5, 50, math.random()*10-5, 10);
	else
		print(key);
	end; 
end;

Window.OnKeyUp = function(key)
	_keys[key] = false;
end;

Window:CreateTimer(12,
	function(uElapse)
		uElapse = uElapse/1000; --sec

		Physic:Update(uElapse);

		if _keys[37] then --влево
			camera:Move(Vector(-cameraSpeed*uElapse,0,0));
		elseif _keys[38] then --вверх
			camera:Move(Vector(0,0,cameraSpeed*uElapse));
		elseif _keys[39] then --вправо
			camera:Move(Vector(cameraSpeed*uElapse,0,0));
		elseif _keys[40] then --вниз
			camera:Move(Vector(0,0,-cameraSpeed*uElapse));
		end;

		Render:OnPaint();
	end
);

Window:Run();