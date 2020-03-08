import { Close20, Pause16, Play16, Settings16 } from '@carbon/icons-react';
import {
    Header,
    HeaderGlobalAction,
    HeaderGlobalBar,
    HeaderName,
    SideNav,
    SideNavItems
} from 'carbon-components-react/lib/components/UIShell';
import * as React from 'react';
import { withRouter } from 'react-router-dom';
import { SidebarLink } from './SidebarLink';

export const NavBar = withRouter(({ history }) => (
    // eslint-disable-next-line @typescript-eslint/ban-ts-ignore
    // @ts-ignore
    <Header style={{ '-webkit-app-region': 'drag' }}>
        <HeaderName prefix="">iTunesRichPresence</HeaderName>
        <HeaderGlobalBar>
            <HeaderGlobalAction
                // eslint-disable-next-line @typescript-eslint/ban-ts-ignore
                // @ts-ignore
                style={{ '-webkit-app-region': 'no-drag' }}
                onClick={window.close}
            >
                <Close20 />
            </HeaderGlobalAction>
        </HeaderGlobalBar>
        <SideNav isRail>
            <SideNavItems>
                <SidebarLink icon={Play16} route="/" history={history} text="Playing Presence" />
                <SidebarLink
                    icon={Pause16}
                    route="/paused"
                    history={history}
                    text="Paused Presence"
                />
                <SidebarLink
                    icon={Settings16}
                    route="/settings"
                    history={history}
                    text="Settings"
                />
            </SideNavItems>
        </SideNav>
    </Header>
));
