
import { Route, Routes } from 'react-router-dom';
import './App.css';
import Layout from './components/shared/Layout';
import ShareYoutubeVideo from './pages/ShareYoutubeVideo';
import YoutubeVideos from './pages/YoutubeVideos';

function App() {
  return (
    <Layout>
      <Routes>
        <Route path="/" element={<YoutubeVideos></YoutubeVideos>}></Route>
      </Routes>
      <Routes>
        <Route path="/share" element={<ShareYoutubeVideo></ShareYoutubeVideo>}></Route>
      </Routes>
    </Layout>
  );
}

export default App;
