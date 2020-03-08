import { Content } from 'carbon-components-react';
import * as React from 'react';
import { hot } from 'react-hot-loader/root';
import { createUseStyles } from 'react-jss';
import { HashRouter as Router, Route, Switch } from 'react-router-dom';
import { AnimatePresence } from 'framer-motion';
import './index.scss';
import { NavBar } from './NavBar';
import { PresencePage } from './pages/PresencePage';
import { SettingsPage } from './pages/SettingsPage';
import { PlayerState } from '../../main/itunes/types';

const useStyles = createUseStyles({
    content: {
        marginLeft: '3rem'
    }
});

const Application = () => {
    const classes = useStyles();
    return (
        <Router>
            <NavBar />
            <Content className={classes.content}>
                <AnimatePresence exitBeforeEnter initial={false}>
                    <Switch>
                        <Route path="/settings" component={SettingsPage} />
                        <Route path="/paused">
                            <PresencePage
                                key="paused"
                                playerState={PlayerState.ITPlayerStateStopped}
                            />
                        </Route>
                        <Route path="/">
                            <PresencePage
                                key="playing"
                                playerState={PlayerState.ITPlayerStatePlaying}
                            />
                        </Route>
                    </Switch>
                </AnimatePresence>
            </Content>
        </Router>
    );
};

export default hot(Application);
