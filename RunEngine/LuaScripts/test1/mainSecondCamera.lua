NotWindowRun = true;

dofile 'LuaScripts\\test1\\main.lua';

local camera2 = Render:NewCamera();
camera2.Map = World:GetMap(0);
camera2.pos = Vector(0, 0, -3);
camera2.BackColor = Color(255,0,0,0);
camera2.ViewPort = Viewport(
	Window.iWidth/2, --X
	Window.iHeight/2, --Y
	Window.iWidth/2, --Width
	Window.iHeight/2, --Height
	0, --MinZ
	1 --MaxZ
);

local backColor = RandomColor(1);
Window:CreateTimer(12,
	function(uElapse)
		camera2.BackColor = backColor:GetColor(uElapse);
	end
);

Window:Run();