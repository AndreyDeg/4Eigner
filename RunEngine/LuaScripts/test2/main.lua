dofile 'LuaScripts\\test2\\sph.lua';
dofile 'LuaScripts\\old\\cube.lua';
dofile 'LuaScripts\\old\\gazelle.lua';
dofile 'LuaScripts\\old\\plane.lua';
dofile 'LuaScripts\\old\\sky.lua';

Window = WindowWinAPI(windowName, windowName);
Render = DirectX(Window);
Physic = PhysX();

local map = World:CreateMap();

--Добавляем свет
local sun = Render:NewDirectLight();
--sun.Type = D3DLIGHT_DIRECTIONAL; //D3DLIGHT_DIRECTIONAL;
sun.Ambient = Color(255, 0.2*255, 0.2*255, 0.2*255);
sun.Diffuse = Color(255, 0.8*255, 0.8*255, 0.8*255);
sun.Specular = Color(255, 0.0, 0.0, 0.0);
sun.Position = Vector(10,10,10);
sun.Direction = Vector(1,1,1);
sun.Range = 1.0;
map:AddLight(sun);

--Добавляем небо
local sky = CreateSky(map, "Pictures\\stormydays_large.jpg", 4, 4);

--Добавляем землю
local ground = CreatePlane(map, "Pictures\\pol.jpg");

local carActive = true;
local car, carDrive = CreateGazelle(map, 0, 1, 0, 100);

local Sph = CreateSphere(map,10,10);

for x = -5, 5 do
	for y = 0, 10 do
		CreateCube(map,x*1.0,0.5+y*1.0,15,0.5,1);
	end;
end;


--Камера
local cameraSpeed = 50;
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

	if _keys[49] then -- 1
		carActive = not carActive;
	end;

	if key == 27 then
		Window:Close();
	elseif key == 32 then
		--CreateSphere(map,30,30);
		CreateCube(map, math.random(), 5, math.random(), 0.3, 10);
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

		if carActive then
			carDrive:Stop();
			if _keys[37] or _keys[65] then --влево
				carDrive:Left();
			end;
			if _keys[38] or _keys[87] then --вперед
				carDrive:Forward();
			end;
			if _keys[39] or _keys[68] then --вправо
				carDrive:Right();
			end;
			if _keys[40] or _keys[83] then --назад
				carDrive:Back();
			end;
			local camx = camera.angle.X;
			local camy = camera.angle.Y;
			camera.pos = Vector(
				car.Actor.pos.X-15*math.sin(camx)*math.cos(camy),
				car.Actor.pos.Y+15*math.sin(camy)+5,
				car.Actor.pos.Z-15*math.cos(camx)*math.cos(camy)
			);
			if camera.pos.Y < 0.2 then
				camera.pos = Vector(camera.pos.X, 0.2, camera.pos.Z);
			end;
		else

			if _keys[37] or _keys[65] then --влево
				camera:Move(Vector(-cameraSpeed*uElapse,0,0));
			end;
			if _keys[38] or _keys[87] then --вперед
				camera:Move(Vector(0,0,cameraSpeed*uElapse));
			end;
			if _keys[39] or _keys[68] then --вправо
				camera:Move(Vector(cameraSpeed*uElapse,0,0));
			end;
			if _keys[40] or _keys[83] then --назад
				camera:Move(Vector(0,0,-cameraSpeed*uElapse));
			end;
			if _keys[33] or _keys[69] then --вверх
				camera:Move(Vector(0,cameraSpeed*uElapse,0));
			end;
			if _keys[34] or _keys[81] then --вниз
				camera:Move(Vector(0,-cameraSpeed*uElapse,0));
			end;
		end;

		Render:OnPaint();
	end
);

Window:Run();