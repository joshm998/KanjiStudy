const {app, BrowserWindow} = require('electron');
const serve = require('electron-serve');

const loadURL = serve({directory: 'wwwroot'});

let mainWindow;

(async () => {
	await app.whenReady();

	mainWindow = new BrowserWindow({
        width: 800,
        height: 600,
    });

    await mainWindow.removeMenu();

	await loadURL(mainWindow);
    
})();