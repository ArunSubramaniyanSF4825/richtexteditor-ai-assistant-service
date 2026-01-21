import express, { Request, Response } from 'express';
import cors from 'cors';
import OpenAI from 'openai';
import { ChatCompletionMessageParam } from 'openai/resources/index.mjs';

const PORT = 3000;

const app = express();
app.use(cors());
app.use(express.json());

app.post('/api/query', async (req: Request, res: Response) => {
  const { message } = req.body as { message: string };
  const messages: ChatCompletionMessageParam[] = [
    { role: 'system', content: 'You are a helpful assistant.' },
    { role: 'user', content: message },
  ];
  
  const client = new OpenAI({ apiKey: 'YOUR_API_KEY' });
  
  try {
    const completion = await client.chat.completions.create({
      model: 'gpt-4o-mini',
      messages,
    });

    const reply = completion.choices[0]?.message?.content ?? '';
    res.status(200).send(reply);
  } catch (error) {
      console.error('Error during query:', error);
      res.status(500).json({
        success: false,
        error: 'Failed to generate response',
      });
  }
});

app.post('/api/stream', async (req: Request, res: Response) => {
  const { message } = req.body as { message: string };
  const promptQuery: ChatCompletionMessageParam[] = [
    { role: 'system', content: 'You are a helpful assistant.' },
    { role: 'user', content: message }
  ];

  const client = new OpenAI({ apiKey: 'YOUR_API_KEY' });

  try {
    const stream = await client.chat.completions.create({
      model: 'gpt-4o-mini',
      stream: true,
      stream_options: {
        include_usage: true
      },
      messages: promptQuery
    });

    for await (const chunk of stream) {
      const delta = chunk.choices?.[0]?.delta?.content || '';
      if (delta) {
        res.write(delta);
      }
    }
    res.end();
  } catch (error) {
    console.error('Error during streaming:', error);
  }
});

app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
