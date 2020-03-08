import { withRouter, useRouteMatch } from 'react-router-dom';
import SideNavLink from 'carbon-components-react/lib/components/UIShell/SideNavLink';
import * as React from 'react';
import * as H from 'history';

type SidebarLinkProps = {
    text: string;
    icon: React.ComponentClass | React.FunctionComponent;
    route: string;
    history: H.History<H.History.PoorMansUnknown>;
};

export const SidebarLink: React.FunctionComponent<SidebarLinkProps> = ({
    history,
    text,
    route,
    icon
}) => {
    const match = useRouteMatch({ path: route, exact: true });
    return (
        <SideNavLink
            onClick={() => {
                history.replace(route);
            }}
            renderIcon={icon}
            // Type annotations package for this component is missing this prop
            // It *does* exist, so we disable the type checking here
            // eslint-disable-next-line @typescript-eslint/ban-ts-ignore
            // @ts-ignore
            isActive={match !== null}
        >
            {text}
        </SideNavLink>
    );
};
