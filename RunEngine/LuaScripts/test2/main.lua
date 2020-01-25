dofile 'LuaScripts\\test2\\sph.lua';

local map = World:CreateMap();
map.Physic = Logic:CreatePhysic();

local Sph = CreateSphere(map,30,30);
map:AddObject(Sph);

local camera = Render:NewCamera();
camera.Map = map;
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
--��������� �������--
---------------------

_keys = {};

--���������� ������� ��� �������� ����
Window.OnMouseMove = function(x, y, keys)
    local camx = (y / Window.iHeight - 0.5) * math.pi;
    local caym = (-x / Window.iWidth - 0.5) * math.pi*2;
	camera.angle = Vector(camx, caym, 0);
end;

--���������� ������� ��� ������� ������
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