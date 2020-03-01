import { ipcMain, IpcMessageEvent } from 'electron';
import * as DiscordRPC from 'discord-rpc';

export default class PresenceManager {
    rpcClient: DiscordRPC.Client;

    constructor() {
        DiscordRPC.register('383816327850360843');
        this.rpcClient = new DiscordRPC.Client({ transport: 'ipc' });
        this.rpcClient.login({ clientId: '383816327850360843' });
        ipcMain.on('update-presence', this.updatePresence.bind(this));
    }

    updatePresence(_event: IpcMessageEvent, details: string, state: string) {
        this.rpcClient.setActivity({
            details,
            state
        });
    }
}
