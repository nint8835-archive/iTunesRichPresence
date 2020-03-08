import { Content } from 'carbon-components-react';
import * as React from 'react';
import { hot } from 'react-hot-loader/root';
import { createUseStyles } from 'react-jss';
import { HashRouter as Router, Route, Switch } from 'react-router-dom';
import './index.scss';
import { NavBar } from './NavBar';
import { PresencePage } from './pages/PresencePage';
import { SettingsPage } from './pages/SettingsPage';

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
                <Switch>
                    <Route path="/settings" component={SettingsPage} />
                    <Route path="/" component={PresencePage} />
                </Switch>
            </Content>
        </Router>
    );
};

export default hot(Application);
