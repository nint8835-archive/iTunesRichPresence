import { ipcMain, IpcMessageEvent } from 'electron';
import * as DiscordRPC from 'discord-rpc';
import getBridge from '../itunes';
import StringProcessor from '../templating/StringProcessor';

export const APP_IDS = {
    iTunes: '383816327850360843',
    'Apple Music': '529435150472183819'
};

export default class PresenceManager {
    rpcClient: DiscordRPC.Client;
    stringProcessor: StringProcessor;

    constructor() {
        DiscordRPC.register('383816327850360843');
        this.rpcClient = new DiscordRPC.Client({ transport: 'ipc' });
        this.rpcClient.login({ clientId: '383816327850360843' });
        this.stringProcessor = new StringProcessor();
        ipcMain.on('update-presence', this.updatePresence.bind(this));
        ipcMain.on('get-song', async () => {
            console.log(await getBridge()?.getCurrentSong());
            console.log(await getBridge()?.getCurrentPosition());
            console.log(await getBridge()?.getPlayerState());
        });
    }

    async updatePresence(_event: IpcMessageEvent, details: string, state: string) {
        this.rpcClient.setActivity({
            details: await this.stringProcessor.render(details),
            state: await this.stringProcessor.render(state)
        });
    }
}
