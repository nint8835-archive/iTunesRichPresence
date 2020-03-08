/**
 * Represents an interface with which we can interact with iTunes.
 */
// eslint-disable-next-line @typescript-eslint/interface-name-prefix
export interface ITunesBridge {
    getCurrentSong(): Promise<CurrentSong | null>;
}

export enum PlaylistKind {
    ITPlaylistUnknown,
    ITPlaylistKindLibrary,
    ITPlaylistKindUser,
    ITPlaylistKindCD,
    ITPlaylistKindDevice,
    ITPlaylistKindRadioTuner
}

export enum PlaylistSpecialKind {
    ITUserPlaylistSpecialKindNone,
    ITUserPlaylistSpecialKindPurchasedMusic,
    ITUserPlaylistSpecialKindPartyShuffle,
    ITUserPlaylistSpecialKindPodcasts,
    ITUserPlaylistSpecialKindFolder,
    ITUserPlaylistSpecialKindVideos,
    ITUserPlaylistSpecialKindMusic,
    ITUserPlaylistSpecialKindMovies,
    ITUserPlaylistSpecialKindTVShows,
    ITUserPlaylistSpecialKindAudiobooks
}

export type Playlist = {
    Name: string;
    Kind: PlaylistKind;
    Duration: number;
    Time: string;
    SpecialKind?: PlaylistSpecialKind;
};

export enum TrackKind {
    ITTrackKindUnknown,
    ITTrackKindFile,
    ITTrackKindCD,
    ITTrackKindURL,
    ITTrackKindDevice,
    ITTrackKindSharedLibrary
}

export type CurrentSong = {
    Name: string;
    Kind: TrackKind;
    Playlist: Playlist;
    Album: string;
    Artist: string;
    BitRate: number;
    BPM: number;
    Comment: string;
    Compilation: boolean;
    Composer: string | null;
    Duration: number;
    Finish: number;
    Genre: string | null;
    PlayedCount: number;
    Start: number;
    Time: string;
    TrackNumber: number;
    Year: number;
    AlbumArtist: string;
};
