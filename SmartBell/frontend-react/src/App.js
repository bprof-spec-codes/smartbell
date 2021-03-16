import React, { Component } from 'react';

import Layout from './components/Layout/Layout';
import TimeTable from './containers/TimeTable/TimeTable';

class App extends Component {
  render() {
    return (
      <div>
        <Layout>
          <h1>Smartbell React frontend.</h1>
          <TimeTable/>
        </Layout>
        
      </div>
    );
  }
}

export default App;
